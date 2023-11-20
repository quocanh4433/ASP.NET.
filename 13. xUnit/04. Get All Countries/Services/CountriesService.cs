using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services;

public class CountriesService : ICountriesService
{
    // private - readonly
    private readonly List<Country> _countries;
    // constructor
    public CountriesService()
    {
        _countries = new List<Country>();
    }

    public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
    {
        // Validator: CountryAddRequest parameter can't be null
        if (countryAddRequest == null)
        {
            throw new ArgumentNullException(nameof(countryAddRequest));
        }

        // Validator: Countryname parameter can't be null
        if (countryAddRequest.CountryName == null)
        {
            throw new ArgumentException(nameof(countryAddRequest.CountryName));
        }

        // Validator: Countryname parameter can't be null
        if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
        {
            throw new ArgumentException("Given country name already exists");
        }

        // Convert object from CountryAddRequest to Country type
        Country country = countryAddRequest.ToCountry();

        // generate countryId
        country.CountryId = Guid.NewGuid();

        // Add country object into _countries
        _countries.Add(country);

        return country.ToCountryResponse();
    }

    public List<CountryResponse> GetAllCountries()
    {
        throw new NotImplementedException();
    }
}

