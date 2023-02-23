using PetShelter.DataAccessLayer.Models;

namespace PetShelter.DataAccessLayer.Repository
{
    public interface IBaseRepository<T> where T : IEntity
    {
        Task Add(T entity);
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task Update(T entity);
    }
}