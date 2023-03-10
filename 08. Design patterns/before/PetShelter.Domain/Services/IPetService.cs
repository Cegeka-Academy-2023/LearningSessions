using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services;

public interface IPetService
{
    Task UpdatePetAsync(int petId, PetInfo petInfo);

    Task<Pet> GetPet(int petId);

    Task<IReadOnlyCollection<Pet>> GetAllPets();
    
    Task<int> RescuePetAsync(Person rescuer, Pet pet);

    Task AdoptPetAsync(Person adopter, int petId);
}
