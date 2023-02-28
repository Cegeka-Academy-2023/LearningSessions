using PetShelter.BusinessLayer.Models;
using DALPerson = PetShelter.DataAccessLayer.Models.Person;

namespace PetShelter.BusinessLayer;

public interface IPersonService
{
    Task<DALPerson> GetOrAddPerson(Person person);
}