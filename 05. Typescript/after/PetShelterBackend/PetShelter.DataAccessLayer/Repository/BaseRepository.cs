using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
{ 
    protected readonly Dictionary<Guid, T> _db = new();

    public Task Add(T entity)
    {
        _db.Add(entity.Id, entity);
        return Task.CompletedTask;
    }

    public Task Update(T entity)
    {
        _db[entity.Id] = entity;
        return Task.CompletedTask;
    }

    public Task<List<T>> GetAll()
    {
        return Task.FromResult(_db.Values.ToList());
    }

    public Task<T?> GetById(Guid id)
    {
        return Task.FromResult(_db[id]);
    }
}
