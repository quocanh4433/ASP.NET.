using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class is used as ReturnTypeEncoder type for most of CountriesService method
    /// </summary>
    public class CountryResponse
    {
        public Guid? CountryId { get; set; }
        public string? CountryName { get; set; }

        // It compare the curent object to another object of CountryResponse type and return true, if both value are the same; otherwise return false
        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj.GetType() != typeof(CountryResponse)) { return false; }
            CountryResponse country_to_compare = (CountryResponse)obj;
            return this.CountryId == country_to_compare.CountryId && this.CountryName == country_to_compare.CountryName;
        }
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { CountryName = country.CountryName, CountryId = country.CountryId };
        }
    }
}

