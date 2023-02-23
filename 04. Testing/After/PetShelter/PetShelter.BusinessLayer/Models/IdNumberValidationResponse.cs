namespace PetShelter.BusinessLayer.Models;

public class IdNumberValidationResponse
{
    public bool IsValid { get; set; }
    public IEnumerable<string> Errors { get; set; }
}