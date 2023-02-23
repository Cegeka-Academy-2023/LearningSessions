using FluentValidation;
using PetShelter.BusinessLayer.ExternalServices;
using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Repository;
using DALPerson = PetShelter.DataAccessLayer.Models.Person;

namespace PetShelter.BusinessLayer;

public class PersonService : IPersonService
{
    private readonly IIdNumberValidator _cnpValidator;
    private readonly IPersonRepository _personRepository;
    private readonly IValidator<Person> _personValidator;

    public PersonService(IPersonRepository personRepository, IIdNumberValidator cnpValidator,
        IValidator<Person> personValidator)
    {
        _personRepository = personRepository;
        _cnpValidator = cnpValidator;
        _personValidator = personValidator;
    }

    public async Task<DALPerson> GetPerson(Person personRequest)
    {
        var person = await GetExistingPerson(personRequest);

        if (person is null) person = await GetNewPerson(personRequest);

        return person;
    }

    private async Task<DALPerson?> GetExistingPerson(Person personRequest)
    {
        var person = await _personRepository.GetPersonByIdNumber(personRequest.IdNumber);

        if (person is not null && person.Name != personRequest.Name)
            throw new ArgumentException("IdNumber doesn't match the name");

        return person;
    }

    private async Task<DALPerson> GetNewPerson(Person personRequest)
    {
        var validationResult = await _personValidator.ValidateAsync(personRequest);
        if (!validationResult.IsValid) throw new ArgumentException();

        var cnpValidationResult = await _cnpValidator.Validate(personRequest.IdNumber);
        if (!cnpValidationResult) throw new ArgumentException("CNP format is invalid");

        var person = new DALPerson
        {
            IdNumber = personRequest.IdNumber,
            DateOfBirth = personRequest.DateOfBirth,
            Name = personRequest.Name
        };

        return person;
    }
}