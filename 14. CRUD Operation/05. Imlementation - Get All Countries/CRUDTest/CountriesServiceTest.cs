﻿using System.Diagnostics.CodeAnalysis;
using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Xunit;

namespace CRUDTest
{
    public class CountriesServiceTest
    {
        // Private readonly
        private readonly ICountriesService _countriesService;

        // Contructor
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region Add
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
            List<CountryResponse> countries_from_GetAllCountries = _countriesService.GetAllCountries();

            // Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, countries_from_GetAllCountries);
        }
        #endregion

        #region GetAllCountries
        [Fact]
        // List of countries shuold be empty by default (before adding any country)
        public void GetAllCountries_EmptyList()
        {
            // Act
            List<CountryResponse> response = _countriesService.GetAllCountries();

            // Assert
            Assert.Empty(response);
        }

        [Fact]
        // List of countries shuold be empty by default (before adding any country)
        public void GetAllCountries_AddFewCountries()
        {
            // Arrange
            List<CountryAddRequest> request = new List<CountryAddRequest>() {
                new CountryAddRequest() { CountryName = "France"},
                new CountryAddRequest() { CountryName = "Colombia"},
            };

            // Act
            List<CountryResponse> countries_from_add_country = new List<CountryResponse>();
            foreach (CountryAddRequest countryRequest in request)
            {
                countries_from_add_country.Add(_countriesService.AddCountry(countryRequest));
            }

            List<CountryResponse> response = _countriesService.GetAllCountries();

            // Read each element from countries_from_add_country
            foreach (CountryResponse countryResponse in countries_from_add_country)
            {
                // Assert
                Assert.Contains(countryResponse, response);
            }

        }
        #endregion
    }
}

