using PetShelter.Api.Adapters;
using PetShelter.Domain;

namespace PetShelter.Api.Adapters
{
    public interface IThirdPartyShelter
    {
        public void RescueBigPet(DataAccessLayer.Models.Pet rescuedPet);
    }
}


public class CustomPetShelter
{
    List<Pet> _pets;
    public CustomPetShelter(List<Pet> pets)
    {
        _pets = pets;
    }

    public void RescuePet(Pet rescuedPet)
    {
        _pets.Remove(rescuedPet);
    }
}


public class CustomPetShelterAdapter : IThirdPartyShelter
{
    private CustomPetShelter _customPetShelter;

    public CustomPetShelterAdapter(CustomPetShelter customPetShelter)
    {
        _customPetShelter = customPetShelter;
    }

    public void RescueBigPet(PetShelter.DataAccessLayer.Models.Pet rescuedPet)
    {
        Pet domainPet = new Pet()
        {
            Name = rescuedPet.Name,
            Description = rescuedPet.Description,
            BirthDate = rescuedPet.Birthdate,
            ImageUrl = rescuedPet.ImageUrl,
            IsHealthy = rescuedPet.IsHealthy,
            WeightInKg = rescuedPet.WeightInKg,
        };
        _customPetShelter.RescuePet(domainPet);
    }
}