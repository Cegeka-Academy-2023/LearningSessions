using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain.Exceptions;
using PetShelter.Domain.Extensions.DomainModel;
using System.Collections.Immutable;
namespace PetShelter.Domain.Services;

public class PetService : IPetService
{

    private readonly IPetRepository petRepository;
    private readonly IPersonRepository personRepository;

    public PetService(IPetRepository petRepository, IPersonRepository personRepository)
    {
        this.petRepository = petRepository;
        this.personRepository = personRepository;
    }


    public async Task AdoptPetAsync(Person adopter, int petId)
    {
        var person = await personRepository.GetPersonByIdNumber(adopter.IdNumber);
        var adoptedPet = await petRepository.GetById(petId);
        adoptedPet.Adopter = person;
        adoptedPet.AdopterId = person.Id;
        adoptedPet.IsSheltered = false;
        await petRepository.Update(adoptedPet);
    }

    public async Task<IReadOnlyCollection<Pet>> GetAllPets()
    {
        var pets = await petRepository.GetAll();
        return pets.Select(p => p.ToDomainModel())
            .ToImmutableArray();
    }

    public async Task<Pet> GetPet(int petId)
    {
        var x = await petRepository.GetById(petId);
        if (x == null)
        {
            return null;
        }
        else
        {
            x.Rescuer = await personRepository.GetById(x.RescuerId.Value);

            if (x.AdopterId.HasValue)
            {
                x.Adopter = personRepository.GetById(x.AdopterId.Value).Result;

            }
            return x.ToDomainModel();
        }
    }

    public async Task<int> RescuePetAsync(Person rescuer, Pet rescuedPet)
    {
        var person = await personRepository.GetPersonByIdNumber(rescuer.IdNumber);


        var databasePet = new DataAccessLayer.Models.Pet();

        databasePet.Birthdate = rescuedPet.BirthDate;
        databasePet.Description = rescuedPet.Description;
        databasePet.ImageUrl = rescuedPet.ImageUrl;
        databasePet.IsHealthy = rescuedPet.IsHealthy;
        databasePet.Name = GeneratePetName(rescuedPet);
        databasePet.Rescuer = person;
        databasePet.RescuerId = person.Id;
        databasePet.Type = rescuedPet.Type.ToString();
        databasePet.WeightInKg = rescuedPet.WeightInKg;
        databasePet.IsSheltered = true;

        await petRepository.Add(databasePet);
        return databasePet.Id;
    }

    private string GeneratePetName(PetInfo rescuedPet)
    {
        var matchingPets = petRepository.GetPetsByName(rescuedPet.Name);
        return AdaptPetNameByOccurrence(rescuedPet, matchingPets.Count);
    }

    private static string AdaptPetNameByOccurrence(PetInfo rescuedPet, int numberOfOccurrences)
    {
        rescuedPet.Name = (numberOfOccurrences % 10) switch
        {
            0 => $"{rescuedPet.Name} the {numberOfOccurrences}st",
            1 => $"{rescuedPet.Name} the {numberOfOccurrences}st",
            2 => $"{rescuedPet.Name} the {numberOfOccurrences}nd",
            3 => $"{rescuedPet.Name} the {numberOfOccurrences}rd",
            _ => $"{rescuedPet.Name} the {numberOfOccurrences}th"
        };

        return rescuedPet.Name;
    }

    public async Task UpdatePetAsync(int petId, PetInfo theNewPetInfo)
    {
        if (!string.IsNullOrEmpty(theNewPetInfo.Name))

        {
            var savedPet = await petRepository.GetById(petId);
            if (savedPet == null)
            {
                throw new NotFoundException($"Pet with id {petId} not found.");
            }

            savedPet.Birthdate = theNewPetInfo.BirthDate;
            savedPet.Description = theNewPetInfo.Description;
            savedPet.ImageUrl = theNewPetInfo.ImageUrl;
            savedPet.IsHealthy = theNewPetInfo.IsHealthy;
            savedPet.Name = theNewPetInfo.Name;
            await petRepository.Update(savedPet);
        }
        else
        {
            throw new ArgumentException($"The TheNewPetInfo has no name");
        }
    }
}