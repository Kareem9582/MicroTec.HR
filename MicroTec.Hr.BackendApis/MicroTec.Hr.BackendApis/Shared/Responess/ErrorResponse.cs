namespace MicroTec.Hr.BackendApi.Shared.Responess
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Error { get; set; } = string.Empty;
        public string? StackTrace { get; set; }
    }
}
