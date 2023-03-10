using FluentValidation;

using PetShelter.Api.Resources;

namespace PetShelter.Api.Validators
{
    public class PersonValidator : AbstractValidator<Resources.Person>
    {
        private static readonly int IdNumberLength = 13;
        private static readonly int MinNameLength = 2;

        public PersonValidator()
        {
            RuleFor(x => x.IdNumber).Length(IdNumberLength);
            RuleFor(x => x.Name).NotEmpty().MinimumLength(MinNameLength);
        }
    }
}
