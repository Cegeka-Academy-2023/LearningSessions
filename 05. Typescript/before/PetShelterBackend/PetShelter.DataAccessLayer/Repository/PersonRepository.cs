using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public async Task<Person?> GetPersonByIdNumber(string idNumber)
    {
        return (await GetAll()).SingleOrDefault(p => p.IdNumber == idNumber);
    }
}