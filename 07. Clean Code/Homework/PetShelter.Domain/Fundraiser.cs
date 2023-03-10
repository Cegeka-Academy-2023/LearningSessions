using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain
{
    public class Fundraiser : INamedEntity
    {
        public string Name { get; set; }
        public int GoalValue { get; set; }
        public string Description { get; set; }
        public Person Owner { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } = true;
        public int CurrentDonation { get; set; } = 0;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public Fundraiser()
        {

        }
        public Fundraiser(string name, int goalValue, string description, Person owner, DateTime dueDate, bool status, int currentDonation, DateTime creationDate)
        {
            Name= name;
            GoalValue= goalValue;
            Description= description;
            Owner= owner;
            DueDate=dueDate;
            Status= status;
            CurrentDonation= currentDonation;
            CreationDate= creationDate;
        }
    }
}
