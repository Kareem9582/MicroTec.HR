namespace MicroTec.Hr.BackendApi.Features.Departments.GetAllDepartment
{
    public class GetAllDepartmentRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
        public string? SearchTerm { get; set; }
    }
}
