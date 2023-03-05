using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services;

public interface IPersonService
{
    Task<Person> GetPerson(int personId);
}