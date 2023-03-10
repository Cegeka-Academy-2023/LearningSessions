using PetShelter.Domain;

namespace PetShelter.Api.Resources;

public class RescuedPet : Pet
{
    public Person Rescuer { get; set; }
    public override decimal GetMaintenanceCost()
    {
        throw new NotImplementedException();
    }
}
