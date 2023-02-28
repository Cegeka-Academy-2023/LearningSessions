namespace PetShelter.Domain;

public class Pet : PetInfo, INamedEntity
{
    public Guid Id { get; }

    public PetType Type { get; }

    public Person Rescuer { get; set; }

    public Person Adopter { get; set; }

    public Pet(PetType type)
    {
        Type = type;
        Id = Guid.NewGuid();
    }
}