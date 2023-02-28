using Microsoft.AspNetCore.Mvc;
using PetShelter.BusinessLayer;
using PetShelter.BusinessLayer.Models;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{
    private readonly ILogger<PetController> _logger;
    private readonly IPetService _petService;

    public PetController(IPetService petService, ILogger<PetController> logger)
    {
        _petService = petService;
        _logger = logger;
    }

    [HttpPost("AdoptPet")]
    public async Task<IActionResult> AdoptPet([FromBody] AdoptPetRequest request)
    {
        await _petService.AdoptPet(request);
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("RescuePet")]
    public async Task<IActionResult> RescuePet([FromBody] RescuePetRequest request)
    {
        await _petService.RescuePet(request);
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Pet>> Get(int id)
    {
        var foundPet = await _petService.GetPet(id);
        if (foundPet is null)
        {
            return NotFound();
        }
        return Ok(foundPet);
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("getAllPets")]
    public async Task<ActionResult<IReadOnlyList<Pet>>> GetPets()
    {
        return Ok(await _petService.GetPets());
    }

    [HttpOptions]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Options()
    {
        Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
        return Ok();
    }

    [HttpPut("changePetName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdatePetName([FromBody]UpdatePetRequest updatePetRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _petService.UpdatePet(updatePetRequest);

     
        return NoContent();
    }

}
