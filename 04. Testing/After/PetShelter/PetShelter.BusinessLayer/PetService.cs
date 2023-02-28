using FluentValidation;
using PetShelter.BusinessLayer.Exceptions;
using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;

namespace PetShelter.BusinessLayer;

public class PetService : IPetService
{
    private readonly IValidator<AdoptPetRequest> _adoptPetValidator;
    private readonly IPersonService _personService;
    private readonly IPetRepository _petRepository;
    private readonly IValidator<RescuePetRequest> _rescuePetValidator;

    public PetService(IPersonService personService, IPetRepository petRepository,
        IValidator<RescuePetRequest> rescuePetValidator, IValidator<AdoptPetRequest> adoptPetValidator)
    {
        _petRepository = petRepository;
        _personService = personService;

        _rescuePetValidator = rescuePetValidator;
        _adoptPetValidator = adoptPetValidator;
    }

    public async Task RescuePet(RescuePetRequest request)
    {
        var validationResult = await _rescuePetValidator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ArgumentException("Request validation failed.");

        var rescuer = await _personService.GetPerson(request.Person);

        var pet = new Pet
        {
            Name = request.PetName,
            Description = request.Description,
            IsHealthy = request.IsHealthy,
            IsSheltered = true,
            Type = request.Type.ToString(),
            WeightInKg = request.WeightInKg,
            ImageUrl = request.ImageUrl,
            Rescuer = rescuer
        };

        await _petRepository.Add(pet);
    }

    public async Task AdoptPet(AdoptPetRequest request)
    {
        var validationResult = await _adoptPetValidator.ValidateAsync(request);
        if (!validationResult.IsValid) throw new ArgumentException("Request validation failed.");

        var adopter = await _personService.GetPerson(request.Person);

        var pet = await _petRepository.GetById(request.PetId);
        if (pet == null) throw new NotFoundException();

        pet.Adopter = adopter;
        pet.IsSheltered = false;

        await _petRepository.Update(pet);
    }

    public async Task<Pet?> GetPet(int petId)
    {
        return await _petRepository.GetById(petId);
    }

    public async Task<IReadOnlyCollection<Pet>> GetPets()
    {
        var pets = await _petRepository.GetAll();
        return pets;
    }

    public async Task UpdatePet(UpdatePetRequest request)
    {
        var pet = await _petRepository.GetById(request.PetId);
        if (pet == null) throw new NotFoundException();

        pet.Name = request.NewPetName;

        await _petRepository.Update(pet);
    }

    public async Task<Pet?> GetPet(string petName)
    {
        var pet = await _petRepository.GetPetByName(petName);
        if (pet == null) throw new NotFoundException($"Could not find pet with name {petName}");

        return pet;
    }

    public async Task<Pet> FindPet(PetFilter petFilter)
    {
        var pet = await _petRepository.GetPetByName(petFilter.PetName);
        if (pet == null) throw new NotFoundException("Couldn't find the pet you were searching for ");

        return pet;
    }
}