namespace PetShelter.BusinessLayer.Models;

public class AdoptPetRequest
{
    public int PetId { get; set; }
    public Person Person { get; set; }
}