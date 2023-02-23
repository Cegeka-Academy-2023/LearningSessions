using PetShelter.BusinessLayer.Models;

namespace PetShelter.BusinessLayer;

public interface IPersonService
{
    Task<int?> GetPersonId(string idNumber);

    Task<int> AddPerson(Person personRequest);
}