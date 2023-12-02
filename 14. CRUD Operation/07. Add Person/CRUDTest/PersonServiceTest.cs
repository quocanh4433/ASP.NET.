
using System;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enum;
using Services;

namespace CRUDTest
{
    public class PersonServiceTest
    {
        // Private - readonly
        private readonly IPersonService _personService;

        // Constructor
        public PersonServiceTest()
        {
            _personService = new PersonService();
        }

        #region AddPerson
        // When we supply null value as PersonAddRequest, it should throw ArgumnetNullException
        [Fact]
        public void AddPerson_NullPerson()
        {
            // Arrange
            PersonAddRequest personAddRequest = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });

        }

        // When we supply null value PersonName, it should throw ArgumnetException
        [Fact]
        public void AddPerson_NullPersonName()
        {
            // Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest() { PersonName = null };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _personService.AddPerson(personAddRequest);
            });

        }

        // When we supply proper Person detail, it should insert the person into person list, it should return an object of PersonResponse, which include with the newly generated person id
        [Fact]
        public void AddPerson_ProperPeronDetail()
        {
            // Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = "Person name...", Email = "person@example.com", Address = "sample address", CountryID = Guid.NewGuid(), Gender = GenderOptions.Male, DateOfBirth = DateTime.Parse("2000-01-01"), ReceiveNewsLetters = true };

            // Act
            PersonResponse person_response_from_add = _personService.AddPerson(personAddRequest);

            List<PersonResponse> person_list = _personService.GetAllPersons();

            // Assert
            Assert.True(person_response_from_add.PersonID != Guid.Empty);
            Assert.Contains(person_response_from_add, person_list);
        }
        #endregion

    }
}

