using MicroTec.Hr.Domain.Shared;

namespace MicroTec.Hr.Domain.Features.Nationality
{
    public class NationalityEntity : BaseReadOnlyEntity
    {
        public string Code { get; set; } = string.Empty; // A short code (e.g., "USA", "CAN")
        public string Name { get; set; } = string.Empty; // Full name of the nationality (e.g., "United States", "Canada")
        public string ISOCode { get; set; } = string.Empty;// The ISO code for the nationality (e.g., "US", "CA")
    }
}
