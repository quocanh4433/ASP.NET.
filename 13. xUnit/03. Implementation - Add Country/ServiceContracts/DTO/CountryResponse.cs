using Entities;

namespace ServiceContracts.DTO
{
    //<summary>
    //DTO class is used as ReturnTypeEncoder type for most of CountriesService method
    //</summary>
    public class CountryResponse
    {
        public Guid? CountryId { get; set; }
        public string? CountryName { get; set; }
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { CountryName = country.CountryName, CountryId = country.CountryId };
        }
    }
}

