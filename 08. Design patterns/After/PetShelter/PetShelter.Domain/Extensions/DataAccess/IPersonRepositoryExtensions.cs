using PetShelter.DataAccessLayer.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Extensions.DataAccess
{
    internal static class IPersonRepositoryExtensions
    {
        public static async Task<DataAccessLayer.Models.Person> GetOrAddPersonAsync(this IPersonRepository repository, DataAccessLayer.Models.Person person)
        {
            var pers = await repository.GetPersonByIdNumber(person.IdNumber);
            if (pers != null)
            {
                return pers;
            }

            await repository.Add(person);
            return await repository.GetPersonByIdNumber(person.IdNumber);
        }
    }
}
