using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain;
using PetShelter.Domain.Exceptions;
using PetShelter.Domain.Extensions.DataAccess;
using PetShelter.Domain.Extensions.DomainModel;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Person1 = PetShelter.DataAccessLayer.Models.Person;
namespace PetShelter.Domain.Services
{
    public class PetServiceClass : IPetServiceInterface
    {
        public PetServiceClass(IPetRepository petRepository, IPersonRepository personRepository)
        {
            PetRepository = petRepository;
            PersonRepository = personRepository;
        }

        public IPetRepository PetRepository;
        public IPersonRepository PersonRepository;

        public async Task AdoptPetAsync(Person adoterPerson, int petId)
        {
            Person1 exisPerson1 = null;
            if (!string.IsNullOrEmpty(adoterPerson.IdNumber))
            {
                if (!string.IsNullOrEmpty(adoterPerson.Name))

                {
                    exisPerson1 = await PersonRepository.GetOrAddPersonAsync(adoterPerson.FromDomainModel());
                }else {
                    throw new ArgumentException($"The adopter has no Id");
                }
            }
            else
            {
             
                    throw new ArgumentException($"The adopter has no name!!!");                
            }            
            var adPet = await PetRepository.GetById(petId);
            adPet.Adopter = exisPerson1;
            adPet.AdopterId = exisPerson1.Id;
            adPet.IsSheltered = false;

            await PetRepository.Update(adPet);
        }

        public async Task<IReadOnlyCollection<Pet>> GetAllPets()
        {
            var pets = await PetRepository.GetAll();
            return pets.Select(p => p.ToDomainModel())
                .ToImmutableArray();
        }

        public async Task<Pet> GetPet(int petId)
        {
            var pet = await PetRepository.GetById(petId);
            if (pet == null)
            {
                return null;
            }
            else
            {
                pet.Rescuer = await PersonRepository.GetById(pet.RescuerId.Value);

                if (pet.AdopterId.HasValue)
                {
                    pet.Adopter =  PersonRepository.GetById(pet.AdopterId.Value).Result;

                }
                return pet.ToDomainModel();
            }
        }

        public async Task<int> RescuePetAsync(Person rescPerson, Pet newRescPet)
        {
            Person1 exisPerson1 = null;
            if (!string.IsNullOrEmpty(rescPerson.IdNumber))
            {
                if (!string.IsNullOrEmpty(rescPerson.Name))

                {
                    exisPerson1 = await PersonRepository.GetOrAddPersonAsync(rescPerson.FromDomainModel());
                }
                else
                {
                    throw new ArgumentException($"The adopter has no Id");
                }
            }
            else
            {

                throw new ArgumentException($"The adopter has no name!!!");
            }


            var exisTPetName = await PetRepository.GetPetByName(newRescPet.Name);

            if(exisTPetName == null)
            {

               
                var rescuedPet = new DataAccessLayer.Models.Pet();



                rescuedPet.Birthdate = newRescPet.BirthDate;
                rescuedPet.Description = newRescPet.Description;
                rescuedPet.ImageUrl = newRescPet.ImageUrl;
                rescuedPet.IsHealthy = newRescPet.IsHealthy;
                rescuedPet.Name = newRescPet.Name;
                rescuedPet.Rescuer = exisPerson1;
                rescuedPet.RescuerId = exisPerson1.Id;
                rescuedPet.Type = newRescPet.Type.ToString();
                rescuedPet.WeightInKg = newRescPet.WeightInKg;
                rescuedPet.IsSheltered = true;

                await PetRepository.Add(rescuedPet);
                return rescuedPet.Id;
            }
            else//need to create a new pet name cause i don't like having same name pets
            {
                long count = 0;
                foreach (var item in await PetRepository.GetAll())
                {
                    if (item.Name.Contains(newRescPet.Name))
                    {
                        count++;
                    }
                    else { continue; }
                }
                //get the number of pets that have the same name. This works weird cause for a pet with the name Rex, another pet with Rexalus will be counted.. Will fix later
                int number =(int) count;
                switch (number % 10)//only take the last digit cause the rest doesn't matter
                {
                    case 1:
                           newRescPet.Name= $"{newRescPet.Name} the {number}st";
                        break;
                    case 2:
                        newRescPet.Name = $"{newRescPet.Name} the {number}nd";
                        break;

                    case 3:
                        newRescPet.Name = $"{newRescPet.Name} the {number}rd";
                        break;  
                    default:
                        newRescPet.Name = $"{newRescPet.Name} the {number}th";
                        break;
                }

                var rescuedPet = new DataAccessLayer.Models.Pet();

                rescuedPet.Birthdate = newRescPet.BirthDate;
                rescuedPet.Description = newRescPet.Description;
                rescuedPet.ImageUrl = newRescPet.ImageUrl;
                rescuedPet.IsHealthy = newRescPet.IsHealthy;
                rescuedPet.Name = newRescPet.Name;
                rescuedPet.Rescuer = exisPerson1;
                rescuedPet.RescuerId = exisPerson1.Id;
                rescuedPet.Type = newRescPet.Type.ToString();
                rescuedPet.WeightInKg = newRescPet.WeightInKg;
                rescuedPet.IsSheltered = true;

                await PetRepository.Add(rescuedPet);
                return rescuedPet.Id;
            }          
        }

        public async Task UpdatePetAsync(int petId, PetInfo theNewPetInfo)
        {
            if (!string.IsNullOrEmpty(theNewPetInfo.Name))

            {
                var savedPet = await PetRepository.GetById(petId);
                if (savedPet == null)
                {
                    throw new NotFoundException($"Pet with id {petId} not found.");
                }

                savedPet.Birthdate = theNewPetInfo.BirthDate;
                savedPet.Description = theNewPetInfo.Description;
                savedPet.ImageUrl = theNewPetInfo.ImageUrl;
                savedPet.IsHealthy = theNewPetInfo.IsHealthy;
                savedPet.Name = theNewPetInfo.Name;
                await PetRepository.Update(savedPet);
            }
            else
            {
                throw new ArgumentException($"The TheNewPetInfo has no name");
            }           
        }
    }


    public interface IPetServiceInterface
    {
        Task UpdatePetAsync(int petId, PetInfo petInfo);

        Task<Pet> GetPet(int petId);

        Task<IReadOnlyCollection<Pet>> GetAllPets();

        Task<int> RescuePetAsync(Person rescuer, Pet pet);

        Task AdoptPetAsync(Person adopter, int petId);
    }


}

