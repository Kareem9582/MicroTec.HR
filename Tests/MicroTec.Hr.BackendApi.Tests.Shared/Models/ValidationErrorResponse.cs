namespace MicroTec.Hr.BackendApi.Tests.Shared.Models
{
    public record ValidationErrorResponse(string Message, List<FieldError> Errors);
}
