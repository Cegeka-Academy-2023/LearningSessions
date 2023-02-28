namespace PetShelter.BusinessLayer.ExternalServices;

public interface IIdNumberValidator
{
    Task<bool> Validate(string idNumber);
}