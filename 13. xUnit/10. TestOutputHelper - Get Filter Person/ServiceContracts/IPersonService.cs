using System;
using ServiceContracts.DTO;

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
    }
}

