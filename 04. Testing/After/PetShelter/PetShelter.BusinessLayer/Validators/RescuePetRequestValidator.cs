using FluentValidation;
using PetShelter.BusinessLayer.Constants;
using PetShelter.BusinessLayer.Models;

namespace PetShelter.BusinessLayer.Validators;

public class RescuePetRequestValidator : AbstractValidator<RescuePetRequest>
{
    public RescuePetRequestValidator()
    {
        RuleFor(x => x.PetName).NotEmpty();
        RuleFor(x => x.Type).IsInEnum();
        RuleFor(x => x.WeightInKg).NotEmpty().LessThan(150).WithMessage(
                $"We only accomodate {string.Join(',', Enum.GetNames(typeof(PetType)))} and all of them weight less than 150kg.")
            .GreaterThan(0);
        RuleFor(x => x.Person).NotEmpty()
            .SetValidator(new PersonValidator());
    }
}