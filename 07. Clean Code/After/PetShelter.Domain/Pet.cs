namespace PetShelter.Domain;

public class Pet : PetInfo, INamedEntity
{
    public int Id { get; }

    public PetType Type { get; }

    public Person Rescuer { get; set; }

    public Person Adopter { get; set; }

    public Pet(PetType type, int id = 0)
    {
        Type = type;
        Id = id;
    }
}