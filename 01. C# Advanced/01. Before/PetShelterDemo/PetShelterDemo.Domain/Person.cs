namespace PetShelterDemo.Domain
{
    public class Person
    {
        public string Name { get; }
        public string IdNumber { get; }

        public Person(string name, string idNumber)
        {
            Name = name;
            IdNumber = idNumber;
        }
    }
}
