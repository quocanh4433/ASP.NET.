using System.Diagnostics.CodeAnalysis;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Xunit;

namespace CRUDTest
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        // When CountryAddrequest is null, it should be throw AgrumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            // Arrange
            CountryAddRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _countriesService.AddCountry(request);
            });
        }


        // When CountryName is null, it shuold be throw Agrumentexception
        [Fact]
        public void AddCountry_NullCountryName()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request);
            });
        }

        // When CountryName is duplicate, it shuold be throw Agrumentexception
        [Fact]
        public void AddCountry_Duplicate()
        {
            // Arrange
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "USA" };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }


        // When you supple proper country name, it should insert (add) the country to the existing list of countries

        [Fact]
        public void AddCountry_ProperCountryDetail()
        {
            // Arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "India" };

            // Act
            CountryResponse? response = _countriesService.AddCountry(request);

            // Assert
            Assert.True(response.CountryId != Guid.Empty);
        }
    }
}

