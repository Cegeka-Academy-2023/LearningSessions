using PetShelter.Domain;

namespace PetShelter.Api.Resources;
public abstract class Pet
{
    public DateTime BirthDate { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public bool IsHealthy { get; set; }

    public string Name { get; set; }

    public decimal WeightInKg { get; set; }

    public abstract decimal GetMaintenanceCost();
}

public class Cat : Pet
{
    public Cat()
    {
        Name = "Catto";
        Description = $"Lazy floof with a cost of {GetMaintenanceCost()}";
    }
    public override decimal GetMaintenanceCost()
    {
        return 10;
    }
}

public class Dog : Pet
{
    public Dog()
    {
        Name = "Doggo";
        Description = $"Good Bouy with a cost of {GetMaintenanceCost()}";
    }
    public override decimal GetMaintenanceCost()
    {
        return 15;
    }
}

public class UndiscoveredPet : Pet
{
    public UndiscoveredPet()
    {
        Name = "You will never know";
        Description = "Cryptid";
        Description = $"Eldritch horror with a cost of {GetMaintenanceCost()}";

    }
    public override decimal GetMaintenanceCost()
    {
        return 20;
    }
}

public static class PetFactory
{
    public static Pet Create(PetType type)
    {
        return type switch
        {
            PetType.Cat => new Cat(),
            PetType.Dog => new Dog(),
            _ => new UndiscoveredPet() };
    }
}
