using PetShelter.Domain.Extensions.DomainModel;
using DomainPet = PetShelter.Domain.Pet;

namespace PetShelter.Domain.Adapters;

public class DataLayerPetAdapter
{
    private readonly DataAccessLayer.Models.Pet dataLayerPet;

    public DataLayerPetAdapter(DataAccessLayer.Models.Pet pet)
    {
        dataLayerPet = pet;
    }

    public DomainPet GetDomainPet()
    {
        return new DomainPet()
        {
            Description = dataLayerPet.Description,
            Name = dataLayerPet.Name,
            Adopter = dataLayerPet.Adopter.ToDomainModel(),
            BirthDate = dataLayerPet.Birthdate,
            ImageUrl = dataLayerPet.ImageUrl,
            IsHealthy = dataLayerPet.IsHealthy,
            Rescuer = dataLayerPet.Rescuer.ToDomainModel(),
            WeightInKg = dataLayerPet.WeightInKg,
        };
      
    }
}