using PetShelter.Domain;

namespace PetShelter.Api.Resources;

public class CreatorOfFundraiser : Fundraiser
{
    public Person Owner { get; set; }
}