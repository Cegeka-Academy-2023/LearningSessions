using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
{ 
    protected readonly PetShelterContext _context;
    public BaseRepository(PetShelterContext context)
    {
        _context = context;
    }

    public async Task Add(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
    }
}
