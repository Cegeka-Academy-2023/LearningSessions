namespace PetShelter.DataAccessLayer.Models;

public class Person: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    ///     Can be used to check if the person is adult or not
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    public string IdNumber { get; set; }

    public ICollection<Pet> RescuedPets { get; set; }
    public ICollection<Pet> AdoptedPets { get; set; }
    public ICollection<Donation> Donations { get; set; }
}