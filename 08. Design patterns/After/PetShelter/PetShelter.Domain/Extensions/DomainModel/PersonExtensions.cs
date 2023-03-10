namespace PetShelter.Domain.Extensions.DomainModel
{
    internal static class PersonExtensions
    {
        public static Person? ToDomainModel(this DataAccessLayer.Models.Person person)
        {
            if (person==null)
            {
                return null;
            }

            return new Person(person.IdNumber, person.Name,person.DateOfBirth);            
        }

        public static DataAccessLayer.Models.Person FromDomainModel(this Person person)
        {
            var entity = new DataAccessLayer.Models.Person
            {
                IdNumber = person.IdNumber,
                Name = person.Name,
                DateOfBirth = person.DateOfBirth,
            };
            return entity;
        }
    }
}
