using PetShelterDemo.DAL;

namespace PetShelterDemo.Domain
{
    internal sealed class Registry<T> : IRegistry<T> where T : INamedEntity
    {
        private readonly Database database; // use DB after async await
        public Registry(Database database)
        {
            this.database = database;
        }

        public async Task Register(T instance) // Implement this after generic types
        {
            await database.Insert(instance);
        }

        public async Task<IReadOnlyList<T>> GetAll() // Implement this after generic types
        {
            return await database.GetAll<T>();
        }

        public async Task<T> GetByName(string name) // implement after LINQ
        {
            return (await database.GetAll<T>()).Single(o => o.Name == name);
        }

        public async Task<IReadOnlyList<T>> Find(Func<T, bool> filter) // implement after lambda expressions
        {
            return (await database.GetAll<T>()).Where(filter).ToList();
        }
    }
}
