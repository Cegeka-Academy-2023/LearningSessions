using FluentValidation;
using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;

namespace PetShelter.BusinessLayer;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _donationRepository;
    private readonly IPersonService _personService;

    public DonationService(IDonationRepository donationRepository,
        IPersonService personService)
    {
        _donationRepository = donationRepository;
        _personService = personService;
    }

    public async Task AddDonation(DonationRequest request)
    {
        var donor = await _personService.GetOrAddPerson(request.Person);

        await _donationRepository.Add(new Donation
        {
            Amount = request.Amount,
            DonorId = donor.Id
        });
    }
}