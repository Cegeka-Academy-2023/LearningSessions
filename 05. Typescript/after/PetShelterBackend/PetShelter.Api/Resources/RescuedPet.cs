using PetShelter.Domain;

namespace PetShelter.Api.Resources;

public class RescuedPet : Pet
{
    public Person Rescuer { get; set; }
}
