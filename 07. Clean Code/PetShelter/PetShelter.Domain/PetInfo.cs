namespace PetShelter.Domain
{
    public class PetInfo
    {
        public DateTime BirthDate { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsHealthy { get; set; }

        public string Name { get; set; }

        public decimal WeightInKg { get; set; }
    }
}