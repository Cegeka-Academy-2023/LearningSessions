using FluentValidation;
using FluentValidation.Results;
using PetShelter.BusinessLayer.Constants;
using PetShelter.BusinessLayer.Models;

namespace PetShelter.BusinessLayer.Validators;

public class DonationRequestValidator : AbstractValidator<DonationRequest>
{
    public DonationRequestValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Person).NotEmpty()
            .SetValidator(new PersonValidator())
            .ChildRules(
                x => x.RuleFor(p => p.DateOfBirth).NotEmpty().Custom((dateOfBirth, context) =>
                {
                    if (DateTime.Now.AddYears(-PersonConstants.AdultMinAge) > dateOfBirth)
                        context.AddFailure(new ValidationFailure("DateOfBirth", "Only adults can make donations."));
                })
            );
    }
}