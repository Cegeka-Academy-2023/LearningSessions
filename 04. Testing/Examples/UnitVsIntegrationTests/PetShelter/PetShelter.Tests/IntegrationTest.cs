using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PetShelter.DataAccessLayer;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;

namespace PetShelter.Tests;

public class IntegrationTest : IDisposable
{
    private readonly PetShelterContext _petShelterContext;
    private IPetRepository _petRepositorySut;
    private Pet _newPet;
    private const string PetName = "Jojo";

    public IntegrationTest()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<PetShelterContext>();
        dbContextOptionsBuilder.UseSqlServer("Server=localhost;Database=PetShelter;Trusted_Connection=True;TrustServerCertificate=True;");

        _petShelterContext = new PetShelterContext(dbContextOptionsBuilder.Options);
        _petRepositorySut = new PetRepository(_petShelterContext);

        _newPet = new Pet { Birthdate = DateTime.Now, Description = "new pet", ImageUrl = "pic.jpg", Name = PetName, IsHealthy = true, IsSheltered = true, WeightInKg = 10, Type = "Cat" };

        _petShelterContext.Pets.Add(_newPet);
        _petShelterContext.SaveChanges();

    }

    [Fact]
    public void GivenAtLeastOnePetWithNameJoho_WhenGetByName_Wrong_ReturnsPetWithNameJojo()
    {
        //Arrange 

        //Act
        var pet = _petRepositorySut.GetPetByName_Wrong(PetName);

        //Assert
        pet.Should().NotBeNull();
        pet.Name.Should().Be(PetName);
    }

    [Fact]
    public void GivenAtLeastOneTornado_WhenGetFirstTornadoWeather_Wrong_ReturnsTornadoWeather()
    {
        //Arrange 

        //Act
        var pet = _petRepositorySut.GetPetByName(PetName);

        //Assert
        pet.Should().NotBeNull();
        pet.Name.Should().Be(PetName);
    }

    public void Dispose()
    {
        _petShelterContext.Remove(_newPet);
        _petShelterContext.SaveChanges();
    }
}