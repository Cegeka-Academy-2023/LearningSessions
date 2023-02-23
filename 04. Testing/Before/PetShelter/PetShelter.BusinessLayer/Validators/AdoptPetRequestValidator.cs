using FluentValidation;
using PetShelter.BusinessLayer.Constants;
using PetShelter.BusinessLayer.Models;

namespace PetShelter.BusinessLayer.Validators;

public class AdoptPetRequestValidator: AbstractValidator<AdoptPetRequest>
{
    public AdoptPetRequestValidator()
    {
        RuleFor(x => x.PetId).NotEmpty();
        RuleFor(x => x.Person).NotEmpty()
            .SetValidator(new PersonValidator());

        RuleFor(x => x.Person.DateOfBirth).LessThan(DateTime.Now.Date.AddYears(-PersonConstants.AdultMinAge))
            .WithMessage("Adopter should be an adult.");
    }
}