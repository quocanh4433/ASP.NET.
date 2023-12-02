using System;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
    public interface IPersonService
    {
        /// <summary>
        /// Add new person into the list persons
        /// </summary>
        /// <param name="personAddRequest">PersonRequest to add</param>
        /// <returns>Return he same person details, along with new generate PersonID</returns>
        PersonResponse AddPerson(PersonAddRequest? personAddRequest);


        /// <summary>
        /// Return all person
        /// </summary>
        /// <returns>Return a list of object of PersonResponse</returns>
        List<PersonResponse> GetAllPersons();

        /// <summary>
        /// Return the person object base on the given person id
        /// </summary>
        /// <param name="personID">Person id to search</param>
        /// <returns>Return the matching person object</returns>
        PersonResponse GetPersonByPersonID(Guid? personID);

        /// <summary>
        /// Return all person object that matching with the given search field and search string
        /// </summary>
        /// <param name="searchBy">Search field to search</param>
        /// <param name="searchString">Search string to search</param>
        /// <returns>Return all matching persons base on thegiven search field and search string</returns>
        List<PersonResponse> GetFilterPerson(string? searchBy, string? searchString);

        /// <summary>
        /// Return sort list of person
        /// </summary>
        /// <param name="allPersons">Represent list of person to sort</param>
        /// <param name="sortBy">Name of property (key), base on which the person should be sort</param>
        /// <param name="sortOrder">ASC and DESC</param>
        /// <returns>Return sorted persons as PersonResponse</returns>
        List<PersonResponse> GetSortPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);

        /// <summary>
        /// Update the specific person detail base on the given person ID
        /// </summary>
        /// <param name="personUpdateRequest">Person detail to update, include person id</param>
        /// <returns>Return the person response object after updatetion</returns>
        PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest);
    }
}

