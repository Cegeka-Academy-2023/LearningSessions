using Azure.Core;
using FluentValidation;
using PetShelter.BusinessLayer.Exceptions;
using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;
using System;

namespace PetShelter.BusinessLayer;

public class PetService : IPetService
{
    private readonly IPersonService _personService;
    private readonly IPetRepository _petRepository;

    public PetService(IPersonService personService, IPetRepository petRepository)
    {
        _petRepository = petRepository;
        _personService = personService;
    }

    public async Task RescuePet(RescuePetRequest request)
    {
        var person = await _personService.GetOrAddPerson(request.Person);
        var pet = new Pet
        {
            Name = request.PetName,
            Description = request.Description,
            IsHealthy = request.IsHealthy,
            IsSheltered = true,
            RescuerId = person.Id,
            Type = request.Type.ToString(),
            WeightInKg = request.WeightInKg,
            ImageUrl = request.ImageUrl,
        };

        await _petRepository.Add(pet);
    }

    public async Task AdoptPet(AdoptPetRequest request)
    {
        var person = await _personService.GetOrAddPerson(request.Person);
        var pet = await _petRepository.GetById(request.PetId);
        if (pet == null) throw new NotFoundException();

        pet.AdopterId = person.Id;
        pet.IsSheltered = false;

        await _petRepository.Update(pet);
    }

    public async Task<Pet> GetPet(int petId)
    {
        var pet = await _petRepository.GetById(petId);
        if (pet == null) throw new NotFoundException($"Could not find pet with pet Id{petId}");

        return pet;
    }

    public async Task<IReadOnlyCollection<Pet>> GetPets()
    {
        var pets = await _petRepository.GetAll();
        return pets;
    }

    public async Task<Pet> FindPet(PetFilter petFilter)
    {

        var pet = await _petRepository.GetPetByName(petFilter.PetName);
        if (pet == null) throw new NotFoundException("Couldn't find the pet you were searching for ");

        return pet;
    }

    public async Task UpdatePet(UpdatePetRequest request)
    {
        var pet = await _petRepository.GetById(request.PetId);
        if (pet == null) throw new NotFoundException();

        pet.Name = request.NewPetName;

        await _petRepository.Update(pet);
    }

    public async Task<Pet> GetPet(string petName)
    {
        var pet = await _petRepository.GetPetByName(petName);
        if (pet == null) throw new NotFoundException($"Could not find pet with name {petName}");

        return pet;
    }
}

