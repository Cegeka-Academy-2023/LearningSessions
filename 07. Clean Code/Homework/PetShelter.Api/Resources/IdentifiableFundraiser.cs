namespace PetShelter.Api.Resources
{
    public class IdentifiableFundraiser:Fundraiser
    {
        public int Id { get; set; }
        public Person Owner { get; set; }
    }
}
