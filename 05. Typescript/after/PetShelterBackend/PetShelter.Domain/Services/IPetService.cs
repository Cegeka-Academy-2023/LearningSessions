using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services;

public interface IPetService
{
    Task UpdatePetAsync(Guid petId, PetInfo petInfo);

    Task<Pet> GetPet(Guid petId);

    Task<IReadOnlyCollection<Pet>> GetAllPets();
    
    Task<Guid> RescuePetAsync(Person rescuer, Pet pet);

    Task AdoptPetAsync(Person adopter, Guid petId);
}
