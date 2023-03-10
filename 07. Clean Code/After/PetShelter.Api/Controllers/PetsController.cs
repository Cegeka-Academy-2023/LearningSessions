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
        private readonly IPetService petService;

        public PetsController(IPetService petService)
        {
            this.petService = petService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentifiablePet>> Get(int id)
        {
            var pet = await this.petService.GetPet(id);
            if (pet is null)
            {
                return this.NotFound();
            }

            return this.Ok(pet.AsResource());
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<IdentifiablePet>>> GetPets()
        {
            var data = await this.petService.GetAllPets();
            return this.Ok(data.Select(p => p.AsResource()).ToImmutableArray());
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Options()
        {
            this.Response.Headers.Add("Allow", "GET, POST, PUT, DELETE, OPTIONS");
            return this.Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RescuePet([FromBody] RescuedPet pet)
        {
            var id = await petService.RescuePetAsync(pet.Rescuer.AsDomainModel(), pet.AsDomainModel());
            return CreatedAtRoute(nameof(RescuePet), id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePet(int id, [FromBody] Resources.Pet pet)
        {
            await this.petService.UpdatePetAsync(id, pet.AsPetInfo());

            return this.NoContent();
        }


        [HttpPost("{id}/adopt")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdoptPet(int id, [FromBody] Resources.Person adopter)
        {
            await petService.AdoptPetAsync(adopter.AsDomainModel(), id);
            return NoContent();
        }
    }
}