using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

using PetShelter.Api.Resources;
using PetShelter.Api.Resources.Extensions;
using PetShelter.Domain;
using System.Collections.Immutable;
using PetShelter.Domain.Services;
using FluentValidation;

namespace PetShelter.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FundraisersController : ControllerBase
    {
        private readonly IFundraiserService _fundraiserService;

        public FundraisersController(IFundraiserService fundraiserService)
        {
            _fundraiserService = fundraiserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<IdentifiableFundraiser>>> GetFundraisers()
        {
            var data = await this._fundraiserService.GetAllFundraisers();
            return this.Ok(data.Select(p => p.AsResource()).ToImmutableArray());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IdentifiableFundraiser>> Get(int id)
        {
            var fundraiser = await this._fundraiserService.GetFundraiser(id);
            if (fundraiser is null)
            {
                return this.NotFound();
            }

            return this.Ok(fundraiser.AsResource());
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateFundraiser(int id, [FromBody] Resources.Fundraiser fundraiser)
        {
            await this._fundraiserService.UpdateFundraiserAsync(id, fundraiser.AsFundraiserInfo());

            return this.NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateFundraise([FromBody] Api.Resources.CreatorOfFundraiser fundraiser)
        {
            var id = await _fundraiserService.CreateFundraiserAsync(fundraiser.Owner.AsDomainModel(), fundraiser.AsDomainModel());
            return CreatedAtRoute(nameof(CreateFundraise), id);
        }
    }
}
