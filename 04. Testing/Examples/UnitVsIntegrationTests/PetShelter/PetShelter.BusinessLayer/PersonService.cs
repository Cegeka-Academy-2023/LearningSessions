using PetShelter.BusinessLayer.ExternalServices;
using PetShelter.DataAccessLayer.Repository;
using DALPerson = PetShelter.DataAccessLayer.Models.Person;

namespace PetShelter.BusinessLayer;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IIdNumberValidator _cnpValidator;

    public PersonService(IPersonRepository personRepository, IIdNumberValidator cnpValidator)
    {
        _personRepository = personRepository;
        _cnpValidator = cnpValidator;
    }

    public async Task<int?> GetPersonId(string idNumber)
    {
        var person = await _personRepository.GetPersonByIdNumber(idNumber);
        return person?.Id;
    }

    public async Task<int> AddPerson(Models.Person personRequest)
    {
        var validationResult = await _cnpValidator.Validate(personRequest.IdNumber);
        if (!validationResult)
        {
            throw new ArgumentException("CNP format is invalid");
        }

        var person = new DALPerson
        {
            IdNumber = personRequest.IdNumber,
            DateOfBirth = personRequest.DateOfBirth,
            Name = personRequest.Name
        };

        await _personRepository.Add(person);

        return person.Id;
    }
}