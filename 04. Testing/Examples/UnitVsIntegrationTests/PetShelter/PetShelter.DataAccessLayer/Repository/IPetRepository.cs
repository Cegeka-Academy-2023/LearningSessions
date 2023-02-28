using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public interface IPetRepository: IBaseRepository<Pet>
{
    Pet? GetPetByName(string name);
    Pet? GetPetByName_Wrong(string name);

}