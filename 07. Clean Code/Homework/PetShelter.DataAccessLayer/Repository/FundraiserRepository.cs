using PetShelter.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Repository
{
    public class FundraiserRepository: BaseRepository<Fundraiser>, IFundraiserRepository
    {
        public FundraiserRepository(PetShelterContext context): base(context)
        {
        }
    }
}
