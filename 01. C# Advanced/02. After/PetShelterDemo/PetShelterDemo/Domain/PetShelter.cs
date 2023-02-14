using PetShelterDemo.ExternalDependencies;

namespace PetShelterDemo.Domain;

public class PetShelter
{
    private readonly IRegistry<Pet> petRegistry;
    private int donationsInRon = 0;

    public PetShelter()
    {
        petRegistry = new Registry<Pet>(new Database());
    }

    public void RegisterPet(Pet pet)
    {
        petRegistry.Register(pet);
    }

    public IReadOnlyList<Pet> GetAllPets()
    {
        return petRegistry.GetAll().Result; // Actually blocks thread until the result is available.
    }

    public Pet GetByName(string name)
    {
        return petRegistry.GetByName(name).Result;
    }

    public void Donate(int amountInRON)
    {
        donationsInRon += amountInRON;
    }

    public int GetTotalDonationsInRON()
    {
        return donationsInRon;
    }
}