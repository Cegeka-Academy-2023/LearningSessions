namespace PetShelter.Api.Resources;

public class Pet
{
    public DateTime BirthDate { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public bool IsHealthy { get; set; }

    public string Name { get; set; }

    public decimal WeightInKg { get; set; }

    public string Type { get; set; }
}
