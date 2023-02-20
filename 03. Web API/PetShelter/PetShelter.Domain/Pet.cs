namespace PetShelter.Domain;

public class Pet : INamedEntity
{
    public string Description { get; }

    public int Id { get; }

    public string ImageUrl { get; set; }

    public bool IsHealthy { get; set; }

    public string Name { get; }

    public DateTime BirthDate { get; }

    public PetType Type { get; }

    public decimal WeightInKg { get; set; }

    public Pet(string name, DateTime birthDate, PetType type, int id = 0)
    {
        Name = name;
        BirthDate = birthDate;
    }
}