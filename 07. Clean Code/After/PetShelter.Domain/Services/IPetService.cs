namespace PetShelter.Domain.Services;

public interface IPetService
{
    Task UpdatePetAsync(int petId, PetInfo petInfo);

    Task<Pet> GetPet(int petId);

    Task<IReadOnlyCollection<Pet>> GetAllPets();

    Task<int> RescuePetAsync(Person rescuer, Pet rescuedPet);

    Task AdoptPetAsync(Person adopter, int petId);
}