using System;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        public PersonService()
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();
        }

        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            // Check if personAddrequest is not Null
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            // Validate PersonName
            if (string.IsNullOrEmpty(personAddRequest.PersonName))
            {
                throw new ArgumentException("PersonName can't be blank");
            }

            // Convert personAddRequest into Person type
            Person person = personAddRequest.ToPerson();

            // Generate person ID
            person.PersonID = Guid.NewGuid();

            // Add person object to person list
            _persons.Add(person);

            // Convert Person object into PersonResponse object
            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => temp.ToPersonResponse()).ToList();
        }

        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null) return null;

            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);

            if (person == null) return null;

            return person.ToPersonResponse();
        }

        public List<PersonResponse> GetFilterPerson(string? searchBy, string? searchString)
        {
            throw new NotImplementedException();
        }
    }
}

