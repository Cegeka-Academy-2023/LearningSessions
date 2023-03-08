using FluentValidation;

namespace PetShelter.Domain.Validators;

public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.IdNumber).Length(PersonConstants.IdNumberLength);
        RuleFor(x => x.Name).NotEmpty().MinimumLength(PersonConstants.NameMinLength);
    }
}


public class PersonConstants
{
    public const int IdNumberLength = 13;
    public const int NameMinLength = 2;
}