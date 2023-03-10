namespace PetShelter.Domain;

public class Pet : PetInfo, INamedEntity
{
    public int Id { get; }
    
    public Person Rescuer { get; set; }

    public Person Adopter { get; set; }

    public Pet( int id = 0)
    {
        
        Id = id;
    }
}