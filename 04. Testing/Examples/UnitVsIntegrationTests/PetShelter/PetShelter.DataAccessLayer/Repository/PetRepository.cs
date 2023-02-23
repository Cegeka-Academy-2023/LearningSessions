using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public class PetRepository : BaseRepository<Pet>, IPetRepository
{
    public PetRepository(PetShelterContext context) : base(context)
    {
    }

    public Pet? GetPetByName(string name)
    {
        return _context.Pets.FirstOrDefault(x => x.Name == name);
    }

    public Pet? GetPetByName_Wrong(string name)
    {
        return _context.Pets.FirstOrDefault(x => FilterName(x, name));
    }

    private bool FilterName(Pet pet, string name)
    {
        if (pet.Name == name)
        {
            return true;
        }
        return false;
    }
}