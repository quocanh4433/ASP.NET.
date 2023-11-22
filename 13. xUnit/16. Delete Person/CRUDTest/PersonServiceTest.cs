
using System;
using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using Services;
using Xunit.Abstractions;

namespace CRUDTest
{
    public class PersonServiceTest
    {
        // Private - readonly
        private readonly IPersonService _personService;
        private readonly ICountriesService _countriesService;
        private readonly ITestOutputHelper _testOutputHelper;

        // Constructor
        public PersonServiceTest(ITestOutputHelper testOutputHelper)
        {
            _personService = new PersonService();
            _countriesService = new CountriesService();
            _testOutputHelper = testOutputHelper;
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

        #region GetPersonByPersonID
        // when we supply null value PersonID, it should return null as PersonResponse
        [Fact]
        public void GetPersonByPersonId_NullPersonID()
        {
            // Arrange
            Guid? personID = null;

            // Act
            PersonResponse person_response_from_get = _personService.GetPersonByPersonID(personID);

            //Assert
            Assert.Null(person_response_from_get);
        }

        // When we supply a valid person id, it should return the valid person details as PersonResponse object
        [Fact]
        public void GetPersonByPersonID_ValidPersonID()
        {
            // Arrange
            CountryAddRequest country_request = new CountryAddRequest() { CountryName = "Brazil" };
            CountryResponse country_response = _countriesService.AddCountry(country_request);

            // Act
            PersonAddRequest person_request = new PersonAddRequest() { PersonName = "person name...", Email = "email@sample.com", Address = "address", CountryID = country_response.CountryID, DateOfBirth = DateTime.Parse("2000-01-01"), Gender = GenderOptions.Male, ReceiveNewsLetters = false };

            PersonResponse person_response = _personService.AddPerson(person_request);

            PersonResponse person_response_from_get = _personService.GetPersonByPersonID(person_response.PersonID);

            // Assert
            Assert.Equal(person_response, person_response_from_get);
        }
        #endregion

        #region GetAllPerson
        // The GetAllPerson() should return empty list by default
        [Fact]
        public void GetAllPersons_EmptyList()
        {
            // Arrange
            List<PersonResponse> person_response_from_get = _personService.GetAllPersons();

            // Assert
            Assert.Empty(person_response_from_get);
        }

        // First, we will add few persons, and then when we call GetAllPerson(), it should return the same persons that were added
        [Fact]
        public void GetAllPersons_AddFewPersons()
        {
            // Arrange
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "India" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response_1.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Mary", Email = "mary@example.com", Gender = GenderOptions.Female, Address = "address of mary", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("2000-02-02"), ReceiveNewsLetters = false };

            PersonAddRequest person_request_3 = new PersonAddRequest() { PersonName = "Rahman", Email = "rahman@example.com", Gender = GenderOptions.Male, Address = "address of rahman", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("1999-03-03"), ReceiveNewsLetters = true };

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            foreach (PersonAddRequest person_request in person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            // Act
            List<PersonResponse> persons_list_from_get = _personService.GetAllPersons();

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var persons_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(persons_from_get.ToString());
            }

            // Assert
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_get);
            }
        }
        #endregion

        #region GetFilterPerson
        // If search text is empty and search by is "PersonName", it should return all persons
        [Fact]
        public void GetFilterPersons_EmptySearchText()
        {
            // Arrange
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "India" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response_1.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Mary", Email = "mary@example.com", Gender = GenderOptions.Female, Address = "address of mary", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("2000-02-02"), ReceiveNewsLetters = false };

            PersonAddRequest person_request_3 = new PersonAddRequest() { PersonName = "Rahman", Email = "rahman@example.com", Gender = GenderOptions.Male, Address = "address of rahman", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("1999-03-03"), ReceiveNewsLetters = true };

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            foreach (PersonAddRequest person_request in person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            // Act
            List<PersonResponse> persons_list_from_get = _personService.GetFilterPerson(nameof(PersonResponse.PersonName), "");

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var persons_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(persons_from_get.ToString());
            }

            // Assert
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                Assert.Contains(person_response_from_add, persons_list_from_get);
            }
        }

        // First we will add few persons, and then we will serach base on person name with some search string. It should return the matching peson
        [Fact]
        public void GetFilterPersons_SearchByPersonName()
        {
            // Arrange
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "India" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response_1.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Mary", Email = "mary@example.com", Gender = GenderOptions.Female, Address = "address of mary", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("2000-02-02"), ReceiveNewsLetters = false };

            PersonAddRequest person_request_3 = new PersonAddRequest() { PersonName = "Rahman", Email = "rahman@example.com", Gender = GenderOptions.Male, Address = "address of rahman", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("1999-03-03"), ReceiveNewsLetters = true };

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            foreach (PersonAddRequest person_request in person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString());
            }

            // Act
            List<PersonResponse> persons_list_from_get = _personService.GetFilterPerson(nameof(PersonResponse.PersonName), "ma");

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var persons_from_get in persons_list_from_get)
            {
                _testOutputHelper.WriteLine(persons_from_get.ToString());
            }

            // Assert
            foreach (PersonResponse person_response_from_add in person_response_list_from_add)
            {
                if (person_response_from_add.PersonName != null)
                {
                    if (person_response_from_add.PersonName.Contains("ma", StringComparison.OrdinalIgnoreCase))
                    {
                        Assert.Contains(person_response_from_add, persons_list_from_get);

                    }
                }
            }
        }
        #endregion

        #region GetSortPerson
        // when we sort base on PersonName in DESC, it should return the person list in descending on PersonName
        [Fact]
        public void GetSortPerson()
        {
            // Arrange
            CountryAddRequest country_request_1 = new CountryAddRequest() { CountryName = "USA" };
            CountryAddRequest country_request_2 = new CountryAddRequest() { CountryName = "India" };

            CountryResponse country_response_1 = _countriesService.AddCountry(country_request_1);
            CountryResponse country_response_2 = _countriesService.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response_1.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Mary", Email = "mary@example.com", Gender = GenderOptions.Female, Address = "address of mary", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("2000-02-02"), ReceiveNewsLetters = false };

            PersonAddRequest person_request_3 = new PersonAddRequest() { PersonName = "Rahman", Email = "rahman@example.com", Gender = GenderOptions.Male, Address = "address of rahman", CountryID = country_response_2.CountryID, DateOfBirth = DateTime.Parse("1999-03-03"), ReceiveNewsLetters = true };

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>() { person_request_1, person_request_2, person_request_3 };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            List<PersonResponse> allPerson = _personService.GetAllPersons();

            foreach (PersonAddRequest person_request in person_requests)
            {
                PersonResponse person_response = _personService.AddPerson(person_request);
                person_response_list_from_add.Add(person_response);
            }

            // Print person response list from add
            _testOutputHelper.WriteLine("Exception: ");
            foreach (var person_response_from_add in person_response_list_from_add)
            {
                _testOutputHelper.WriteLine(person_response_from_add.ToString() + "\n");
            }

            // Act
            List<PersonResponse> persons_list_from_sort = _personService.GetSortPersons(allPerson, nameof(Person.PersonName), SortOrderOptions.DESC);

            // Print person response list from sort
            _testOutputHelper.WriteLine("Actual: ");
            foreach (PersonResponse persons_from_sort in persons_list_from_sort)
            {
                _testOutputHelper.WriteLine(persons_from_sort.ToString() + "\n");
            }

            person_response_list_from_add = person_response_list_from_add.OrderByDescending(temp => temp.PersonName).ToList();

            // Assert
            for (int i = 0; i < person_response_list_from_add.Count; i++)
            {
                Assert.Equal(person_response_list_from_add[i], persons_list_from_sort[i]);
            }

        }
        #endregion

        #region UpdatePerson
        // When we supply the null PersonupdateRequest, it should throw ArgumentNullException
        [Fact]
        public void UpdatePerson_NullPerson()
        {
            // Arrange
            PersonUpdateRequest person_update_request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        // When we supply the null PersonName, it should throw ArgumentException
        [Fact]
        public void UpdatePerson_InvalidPersonID()
        {
            // Arrange
            PersonUpdateRequest? person_update_request = new PersonUpdateRequest() { PersonID = Guid.NewGuid() };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        // When we supply the null PersonName, it should throw ArgumentException
        [Fact]
        public void UpdatePerson_NullPersonName()
        {
            // Arrange
            CountryAddRequest country_request = new CountryAddRequest() { CountryName = "USA" };
            CountryResponse country_response = _countriesService.AddCountry(country_request);

            PersonAddRequest person_request = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonResponse person_response_from_add = _personService.AddPerson(person_request);

            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();

            person_update_request.PersonName = null;

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                _personService.UpdatePerson(person_update_request);
            });
        }

        // First add a new person and try to update person name and email
        [Fact]
        public void UpdatePerson_PersonFullDetailupdation()
        {
            // Arrange
            CountryAddRequest country_request = new CountryAddRequest() { CountryName = "USA" };
            CountryResponse country_response = _countriesService.AddCountry(country_request);

            PersonAddRequest person_request = new PersonAddRequest() { PersonName = "Smith", Email = "smith@example.com", Gender = GenderOptions.Male, Address = "address of smith", CountryID = country_response.CountryID, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };

            PersonResponse person_response_from_add = _personService.AddPerson(person_request);

            PersonUpdateRequest person_update_request = person_response_from_add.ToPersonUpdateRequest();

            person_update_request.PersonName = "John";
            person_update_request.Email = "johncena@gmail.com";

            // Act
            PersonResponse person_response_from_update = _personService.UpdatePerson(person_update_request);

            PersonResponse person_response_from_get = _personService.GetPersonByPersonID(person_response_from_update.PersonID);

            // Assert
            Assert.Equal(person_response_from_update, person_response_from_get);

        }


        #endregion

        #region DeletePerson
        // If you supply the valid person id, it should reutrn true
        public void DeletePerson_ValidPersonID()
        {
            //Arrange
            CountryAddRequest country_add_request = new CountryAddRequest() { CountryName = "USA" };
            CountryResponse country_response_from_add = _countriesService.AddCountry(country_add_request);

            PersonAddRequest person_add_request = new PersonAddRequest() { PersonName = "Jones", Address = "address", CountryID = country_response_from_add.CountryID, DateOfBirth = Convert.ToDateTime("2010-01-01"), Email = "jones@example.com", Gender = GenderOptions.Male, ReceiveNewsLetters = true };

            PersonResponse person_response_from_add = _personService.AddPerson(person_add_request);


            //Act
            bool isDeleted = _personService.DeletePerson(person_response_from_add.PersonID);

            //Assert
            Assert.True(isDeleted);
        }

        // If you supply the invalid person id, it should reutrn false
        public void DeletePerson_InValidPersonID()
        {
            //Act
            bool isDeleted = _personService.DeletePerson(Guid.NewGuid());

            //Assert
            Assert.False(isDeleted);
        }

        #endregion
    }
}

