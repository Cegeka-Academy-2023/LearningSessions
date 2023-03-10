using FluentValidation;

using PetShelter.Api.Resources;
using PetShelter.Domain;

namespace PetShelter.Api.Validators
{
    public class RescuedPetValidator:AbstractValidator<RescuedPet>
    {
        public RescuedPetValidator()
        {
            RuleFor(_ => _.Type).IsEnumName(typeof(PetType));
            RuleFor(_ => _.WeightInKg).GreaterThan(0.1m);
            RuleFor(_ => _.Name).MinimumLength(PetValidationConstants.MinNameLength);
            RuleFor(_=>_.Rescuer).SetValidator(new PersonValidator());
        }
    }
}
