using PetShelter.DataAccessLayer.Models;

namespace PetShelter.BusinessLayer.Models;

public class UpdatePetRequest
{
    public int PetId { get; set; }
    public string  NewPetName { get; set; }
}
