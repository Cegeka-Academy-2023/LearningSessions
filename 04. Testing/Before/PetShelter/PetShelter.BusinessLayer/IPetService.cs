using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.BusinessLayer;

public interface IPetService
{
    Task RescuePet(RescuePetRequest request);
    Task AdoptPet(AdoptPetRequest request);
    Task UpdatePet(UpdatePetRequest request);
    Task<Pet?> GetPet(int petId);
    Task<Pet?> GetPet(string petName);
    Task<IReadOnlyCollection<Pet>> GetPets();
}