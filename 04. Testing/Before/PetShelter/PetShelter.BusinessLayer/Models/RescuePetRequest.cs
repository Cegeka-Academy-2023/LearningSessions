using PetShelter.BusinessLayer.Constants;

namespace PetShelter.BusinessLayer.Models;

public class RescuePetRequest
{
    public string PetName { get; set; }
    public string Description { get; set; }
    public PetType Type { get; set; }
    public bool IsHealthy { get; set; }
    public decimal WeightInKg { get; set; }
    public string ImageUrl { get; set; }
    public Person Person { get; set; }
}