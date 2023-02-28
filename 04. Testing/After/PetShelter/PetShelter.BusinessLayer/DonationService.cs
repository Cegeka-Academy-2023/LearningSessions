using FluentValidation;
using PetShelter.DataAccessLayer.Repository;

namespace PetShelter.BusinessLayer.Tests;

public class DonationService
{
    private readonly IDonationRepository _donationRepository;
    private readonly IValidator<AddDonationRequest> _donationValidator;

    public DonationService(IDonationRepository donationRepository, IValidator<AddDonationRequest> validator)
    {
        _donationValidator = validator;
        _donationRepository = donationRepository;
    }

    public async Task AddDonation(AddDonationRequest addDonationRequest)
    {
        var validationResult = _donationValidator.Validate(addDonationRequest);
        if(!validationResult.IsValid) { throw new ArgumentException(); }

        await _donationRepository.Add(new DataAccessLayer.Models.Donation
        {
            Amount= addDonationRequest.Amount
        });
    }
}