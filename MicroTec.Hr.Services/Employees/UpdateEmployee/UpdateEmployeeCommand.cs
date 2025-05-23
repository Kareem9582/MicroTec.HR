﻿using MediatR;
using MicroTec.Hr.Domain.Enums;
using MicroTec.Hr.Services.Custodies;

namespace MicroTec.Hr.Services.Employees.UpdateEmployee
{
    public record class UpdateEmployeeCommand : IRequest
    {
        public Guid EmployeeId { get; init; }
        public string FullName { get; init; } = default!;
        public DateTimeOffset BirthDate { get; init; }
        public Gender Gender { get; init; }
        public Guid NationalityId { get; init; }
        public Guid UserId { get; init; }
        public IEnumerable<Custody> Custodies { get; init; } = [];
    }
}
