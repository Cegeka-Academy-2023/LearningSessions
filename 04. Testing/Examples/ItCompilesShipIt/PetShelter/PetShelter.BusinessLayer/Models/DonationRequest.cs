namespace PetShelter.BusinessLayer.Models;

public class DonationRequest
{
    public decimal Amount { get; set; }
    public Person Person { get; set; }
}