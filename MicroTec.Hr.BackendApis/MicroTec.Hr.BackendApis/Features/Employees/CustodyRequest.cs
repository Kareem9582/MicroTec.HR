namespace MicroTec.Hr.BackendApi.Features.Employees
{
    public record class CustodyRequest(string? CustodyNumber, string CustodyName,string CustodyDescription, DateTimeOffset AssignDate);
}
