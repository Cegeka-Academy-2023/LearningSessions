namespace PetShelter.Api.Resources;

public class IdentifiablePet:Pet
{
    public Guid Id { get; set; }

    public Person Rescuer { get; set; }

    public Person Adopter { get; set; }
}
