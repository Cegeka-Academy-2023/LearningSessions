using Microsoft.AspNetCore.Mvc;

using PetShelter.Api.Resources;
using PetShelter.Api.Resources.Extensions;
using System.Collections.Immutable;
using PetShelter.Domain.Services;

namespace PetShelter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentifiablePet>> Get(Guid id)
        {
            var pet = await _petService.GetPet(id);
            if (pet is null)
            {
                return NotFound();
            }

            return Ok(pet.AsResource());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<IdentifiablePet>>> GetPets()
        {
            var data = await _petService.GetAllPets();
            return Ok(data.Select(p => p.AsResource()).ToImmutableArray());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RescuePet([FromBody] RescuedPet pet)
        {
            await _petService.RescuePetAsync(pet.Rescuer.AsDomainModel(), pet.AsDomainModel());
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePet(Guid id, [FromBody] Pet pet)
        {
            await _petService.UpdatePetAsync(id, pet.AsPetInfo());

            return NoContent();
        }


        [HttpPost("{id}/adopt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdoptPet(Guid id, [FromBody] Person adopter)
        {
            await _petService.AdoptPetAsync(adopter.AsDomainModel(), id);
            return NoContent();
        }
    }
}