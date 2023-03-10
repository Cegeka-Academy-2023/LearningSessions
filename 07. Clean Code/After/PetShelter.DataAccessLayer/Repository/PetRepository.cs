using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public class PetRepository : BaseRepository<Pet>, IPetRepository
{
    public PetRepository(PetShelterContext context) : base(context)
    {
    }

    public async Task<Pet?> GetPetByName(string name)
    {
        return await _context.Pets.FirstOrDefaultAsync(p => p.Name.Equals(name));
    }

    public IReadOnlyCollection<Pet> GetPetsByName(string name)
    {
        return  _context.Pets.Where(p => p.Name.Contains(name)).ToImmutableArray();
    }
}