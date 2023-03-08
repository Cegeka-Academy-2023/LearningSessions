using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Extensions.DomainModel
{
    internal static class PetExtensions
    {
        public static Pet? ToDomainModel(this DataAccessLayer.Models.Pet pet)
        {
            if (pet==null)
            {
                return null;
            }

            var petType = Enum.Parse<PetType>(pet.Type);
            var domainModel = new Pet(petType, id: pet.Id);
            domainModel.Name = pet.Name;
            domainModel.BirthDate= pet.Birthdate;
            domainModel.Description = pet.Description;
            domainModel.IsHealthy = pet.IsHealthy;
            domainModel.ImageUrl = pet.ImageUrl;
            domainModel.WeightInKg = pet.WeightInKg;
            domainModel.Adopter = pet.Adopter.ToDomainModel();
            domainModel.Rescuer = pet.Rescuer.ToDomainModel();
            return domainModel;
        }
        
    }
}
