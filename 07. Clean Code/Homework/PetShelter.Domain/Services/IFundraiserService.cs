using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services
{
    public interface IFundraiserService
    {
        Task<Fundraiser> GetFundraiser(int fundraiserId);
        Task<IReadOnlyCollection<Fundraiser>> GetAllFundraisers();
        Task UpdateFundraiserAsync(int fundraiserId, Fundraiser fundraiser);
        Task<int> CreateFundraiserAsync(Person owner, Fundraiser fundraiser);
    }
}
