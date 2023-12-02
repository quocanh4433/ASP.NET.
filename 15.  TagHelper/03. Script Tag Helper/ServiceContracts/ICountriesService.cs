using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic for manuplating Country enities
/// </summary>

public interface ICountriesService
{
    /// <summary>
    /// Adds a country object to the list of countries
    /// </summary>
    /// <param name="countryAddRequest">Country object to add</param>
    /// <returns>Returns the country object after adding it (including newly generated country id)</returns>
    CountryResponse AddCountry(CountryAddRequest? countryAddRequest);

    /// <summary>
    /// Return all countries from the list
    /// </summary>
    /// <returns>All countries from the list as a List of CountryResponse"</returns>
    List<CountryResponse> GetAllCountries();

    /// <summary>
    /// Return country object based on the given country ID
    /// </summary>
    /// <param name="CountryID"></param>
    /// <returns>Matching country as CountryResponse object</returns>
    CountryResponse? GetCountryByCountryID(Guid? CountryID);
}

