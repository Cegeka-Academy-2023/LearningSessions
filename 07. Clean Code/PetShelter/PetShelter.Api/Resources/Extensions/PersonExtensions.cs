namespace PetShelter.Api.Resources.Extensions;

public static class PersonExtensions
{
    public static Domain.Person AsDomainModel(this Person person)
    {
        return new Domain.Person(person.IdNumber, person.Name, person.DateOfBirth);
    }

    public static Person AsResource(this Domain.Person person)
    {
        return new Person
        {
            DateOfBirth = person.DateOfBirth,
            IdNumber = person.IdNumber,
            Name = person.Name,
        };
    }
}