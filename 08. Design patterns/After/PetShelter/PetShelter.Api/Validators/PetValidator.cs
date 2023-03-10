using FluentValidation;

using PetShelter.Domain;

namespace PetShelter.Api.Validators
{
    public class PetValidator:AbstractValidator<Resources.Pet>
    {
        

        public PetValidator()
        {
            RuleFor(_ => _.WeightInKg).GreaterThan(0.1m);
            RuleFor(_=>_.Name).MinimumLength(PetValidationConstants.MinNameLength);
        }
    }
}
