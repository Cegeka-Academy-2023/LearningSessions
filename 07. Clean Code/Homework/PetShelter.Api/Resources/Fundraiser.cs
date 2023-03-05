namespace PetShelter.Api.Resources;

public class Fundraiser
{
    public string Name { get; set; }
    public int GoalValue { get; set; }
    public string Description { get; set; }
    //public Person Owner { get; set; }
    public DateTime DueDate { get; set; }
    public bool Status { get; set; } = true;
    public int CurrentDonation { get; set; } = 0;
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
