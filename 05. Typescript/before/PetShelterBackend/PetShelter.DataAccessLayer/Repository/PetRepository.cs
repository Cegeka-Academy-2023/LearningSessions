using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public class PetRepository : BaseRepository<Pet>, IPetRepository
{
    public async Task<Pet?> GetPetByName(string name)
    {
        return (await GetAll()).FirstOrDefault(p => p.Name.Equals(name));
    }
}