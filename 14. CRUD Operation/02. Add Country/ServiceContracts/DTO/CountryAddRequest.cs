using System;
using Entities;

namespace ServiceContracts.DTO
{
    //<summary>
    // DTO class for add a new country
    //</summary>
    public class CountryAddRequest
    {
        public string? CountryName { set; get; }

        public Country ToCountry()
        {
            return new Country() { CountryName = CountryName };
        }
    }
}

