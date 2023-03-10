namespace PetShelter.DataAccessLayer.Models;

public class Donation: IEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    /// <summary>
    ///     FK to a person
    /// </summary>
    public int DonorId { get; set; }

    public Person Donor { get; set; }
}