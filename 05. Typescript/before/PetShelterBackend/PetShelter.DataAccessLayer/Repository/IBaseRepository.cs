using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task Add(T entity);
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task Update(T entity);
    }
}