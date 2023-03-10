using PetShelter.Domain;

namespace PetShelter.Api.Resources.Extensions;

public static class PetExtensions
{
    public static Domain.PetInfo AsPetInfo(this Pet pet)
    {
        return new Domain.PetInfo
        {
            BirthDate = pet.BirthDate,
            Description = pet.Description,
            ImageUrl = pet.ImageUrl,
            IsHealthy = pet.IsHealthy,
            Name = pet.Name,
            WeightInKg = pet.WeightInKg,
        };
    }

    public static Domain.Pet AsDomainModel(this RescuedPet pet)
    {
        var petType = Enum.Parse<PetType>(pet.Type);
        var domainModel = new Domain.Pet(petType);
        domainModel.Name = pet.Name;
        domainModel.BirthDate = pet.BirthDate;
        domainModel.Description = pet.Description;
        domainModel.IsHealthy = pet.IsHealthy;
        domainModel.ImageUrl = pet.ImageUrl;
        domainModel.WeightInKg = pet.WeightInKg;
        domainModel.Rescuer = pet.Rescuer.AsDomainModel();
        return domainModel;
    }

    public static IdentifiablePet AsResource(this Domain.Pet pet)
    {
        return new IdentifiablePet
        {
            Id = pet.Id,
            BirthDate = pet.BirthDate,
            Description = pet.Description,
            ImageUrl = pet.ImageUrl,
            IsHealthy = pet.IsHealthy,
            Name = pet.Name,
            Type = pet.Type.ToString(),
            WeightInKg = pet.WeightInKg,
            Adopter = pet.Adopter?.AsResource(),
            Rescuer = pet.Rescuer?.AsResource(),
        };
    }
}
