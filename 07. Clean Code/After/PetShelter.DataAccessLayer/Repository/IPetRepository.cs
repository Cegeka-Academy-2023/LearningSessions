using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public interface IPetRepository: IBaseRepository<Pet>
{
    Task<Pet?> GetPetByName(string name);
    IReadOnlyCollection<Pet> GetPetsByName(string name);
}