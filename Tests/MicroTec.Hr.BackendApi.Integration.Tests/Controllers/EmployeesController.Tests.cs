using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MicroTec.Hr.BackendApi.Tests.Shared.Factories.Employee;
using MicroTec.Hr.BackendApi.Tests.Shared.Models;
using MicroTec.Hr.Infrastructure.Contexts;
using System.Net;
using System.Net.Http.Json;

namespace MicroTec.Hr.BackendApi.Integration.Tests.Controllers
{
    public class EmployeesControllerTests : IClassFixture<EmployeeDatabaseFactory>
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _dbContext;
        private readonly IServiceScope _scope;
        private const string CONTROLLER_PATH = $"/api/v1/Employees";
        public EmployeesControllerTests(EmployeeDatabaseFactory factory)
        {
            _client = factory.CreateClient();
            // Create explicit scope for DbContext
            _scope = factory.Services.CreateScope();
            _dbContext = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        [Fact]
        public async Task CreateEmployee_ValidRequest_Returns201AndCreatesRecord()
        {
            // Arrange
            var request = EmployeeFactory.ValidRequest();
            // Act
            var response = await _client.PostAsJsonAsync(CONTROLLER_PATH, request);
            var employeeId = await response.Content.ReadFromJsonAsync<Guid>();

            // Assert - API Response

            response.Headers.Location.Should().NotBeNull();
            response.Headers.Location!.LocalPath.Should().Be(CONTROLLER_PATH + $"/{employeeId}"); // ← Compare paths only

            // Assert - Database
            var savedEmployee = await _dbContext.Employees.FindAsync(employeeId);
            savedEmployee.Should().NotBeNull();
            savedEmployee!.EmployeeCode.Should().Be(request.EmployeeCode);
        }

        [Fact]
        public async Task CreateEmployee_InvalidRequest_Returns400()
        {
            var request = EmployeeFactory.InvalidBirthDateTooYoung();
            var response = await _client.PostAsJsonAsync(CONTROLLER_PATH, request);

            // Assert - Status Code
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Assert - Error Structure
            var errorResponse = await response.Content.ReadFromJsonAsync<ValidationErrorResponse>();
            errorResponse.Should().NotBeNull();
            errorResponse.Message.Should().Be("Validation failed");

            // Find the BirthDate error specifically
            var birthDateError = errorResponse.Errors
                .FirstOrDefault(e => e.Field == "BirthDate");

            birthDateError.Should().NotBeNull();
            birthDateError.Errors.Should().Contain(
                "Employee must be between 16 and 65 years old.");
        }
    }
}