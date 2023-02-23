using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using PetShelter.DataAccessLayer;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;

namespace PetShelter.Tests;
public class UnitTest
{
    private readonly Mock<PetShelterContext> _mockContext;
    private readonly IPetRepository _petRepositorySut;

    public UnitTest()
    {
        _mockContext = new Mock<PetShelterContext>();
        _petRepositorySut = new PetRepository(_mockContext.Object);

    }

    [Fact]
    public void GivenAtLeastOnePetWithNameMax_WhenGetByName_Wrong_ReturnsPetWithNameMax()
    {
        //Arrange 
        var petName = "Max";
        var data = new List<Pet>
        {
            new() { Name = petName }
        }.AsQueryable();

        var mockPetSet = SetupMockDbSet(data);
        _mockContext.Setup(x => x.Pets).Returns(mockPetSet.Object);

        //Act
        var pet = _petRepositorySut.GetPetByName_Wrong(petName);

        //Assert
        pet.Should().NotBeNull();
        pet.Name.Should().Be(petName);
    }

    [Fact]
    public void GivenAtLeastOnePetWithNameMax_WhenGetByName_ReturnsPetWithNameMax()
    {
        //Arrange 
        var petName = "Max";
        var data = new List<Pet>
        {
            new() { Name = petName }
        }.AsQueryable();

        var mockPetSet = SetupMockDbSet(data);
        _mockContext.Setup(x => x.Pets).Returns(mockPetSet.Object);

        //Act
        var pet = _petRepositorySut.GetPetByName(petName);

        //Assert
        pet.Should().NotBeNull();
        pet.Name.Should().Be(petName);
    }

    private Mock<DbSet<Pet>> SetupMockDbSet<T>(IQueryable<T> data)
    {
        // https://learn.microsoft.com/en-us/ef/ef6/fundamentals/testing/mocking

        var mockWeatherSet = new Mock<DbSet<Pet>>();

        mockWeatherSet.As<IQueryable<Pet>>().Setup(m => m.Provider).Returns(data.Provider);
        mockWeatherSet.As<IQueryable<Pet>>().Setup(m => m.Expression).Returns(data.Expression);
        mockWeatherSet.As<IQueryable<Pet>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockWeatherSet.As<IQueryable<Pet>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        return mockWeatherSet;
    }
}