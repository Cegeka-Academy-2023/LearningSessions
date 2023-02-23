using PetShelter.DataAccessLayer.Models;

namespace PetShelter.BusinessLayer;

public interface IPersonService
{
    Task<Person> GetPerson(Models.Person personRequest);
}