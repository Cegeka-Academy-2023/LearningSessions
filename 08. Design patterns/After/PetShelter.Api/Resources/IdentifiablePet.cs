namespace PetShelter.Api.Resources;

public class IdentifiablePet:Pet
{
    public int Id { get; set; }

    public Person Rescuer { get; set; }

    public Person Adopter { get; set; }
    public override decimal GetMaintenanceCost()
    {
        throw new NotImplementedException();
    }
}
