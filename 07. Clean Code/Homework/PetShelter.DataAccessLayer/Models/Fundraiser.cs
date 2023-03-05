using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Models
{
    public class Fundraiser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoalValue { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public Person Owner { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; } = true;
        public int CurrentDonation { get; set; } = 0;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public ICollection<Person> Donors { get; set; }
    }
}
