using Microsoft.AspNetCore.Mvc;
using PetShelter.BusinessLayer;
using PetShelter.BusinessLayer.Models;

namespace PetShelter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DonationController : ControllerBase
{
    private readonly IDonationService _donationService;
    private readonly ILogger<PetController> _logger;

    public DonationController(IDonationService donationService, ILogger<PetController> logger)
    {
        _donationService = donationService;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddDonation(DonationRequest request)
    {
        await _donationService.AddDonation(request);
        return Ok();
    }
}