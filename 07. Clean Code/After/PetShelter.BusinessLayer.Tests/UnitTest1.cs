using FluentAssertions;
using Moq;

using PetShelter.Domain.Services;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain.Services;
using Person = PetShelter.Domain.Person;

namespace PetShelter.BusinessLayer.Tests
{
    public class RescuePetTests
    {
        private readonly IPetService _petServiceSut;

        private readonly Mock<IPersonRepository> _mockPersonRepository;
        private readonly Mock<IPetRepository> _mockPetRepository;

        public RescuePetTests()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _mockPetRepository = new Mock<IPetRepository>();

            
            _petServiceSut = new PetService(_mockPetRepository.Object, _mockPersonRepository.Object);
        }

        private void SetupHappyPath()
        {

            //_request = new RescuePetRequest
            //{
            //    PetName = "Max",
            //    Type = Constants.PetType.Dog,
            //    Description = "Nice dog",
            //    IsHealthy = true,
            //    ImageUrl = "test",
            //    WeightInKg = 10,
            //    Person = new BusinessLayer.Models.Person
            //    {
            //        DateOfBirth = DateTime.Now.AddYears(-Constants.PersonConstants.AdultMinAge),
            //        IdNumber = "1111222233334",
            //        Name = "TestName"
            //    }
            //};
        }

        [Fact]
        public async void GivenValidData_WhenRescuePet_PetIsAdded()
        {
            //Arrange
            SetupHappyPath();
            var petId = "1111222233334";
            var adoptingPerson = new Person("12", "John wick", DateTime.Now);
            //_mockPersonRepository.Object.GetPersonByIdNumber(Arg)
            //Act
            await _petServiceSut.AdoptPetAsync(adoptingPerson,1 );

            //Assert
           // _mockPetRepository.Verify(x => x.Add(It.Is<Pet>(p => p.Name == _request.PetName)), Times.Once);
        }

        [Theory]
        [InlineData(200)]
        [InlineData(-5)]
        [InlineData(0)]
        public async Task GiventWeightIsInvalid_WhenRescuePet_ThenThrowsArgumentException_And_PetIsNotAdded(decimal weight)
        {
            // Arrange
            //SetupHappyPath();
            //_request.WeightInKg = weight;

            ////Act
            //await Assert.ThrowsAsync<ArgumentException>(() => _petServiceSut.RescuePet(_request));

            ////Assert
            //_mockPetRepository.Verify(x => x.Add(It.Is<Pet>(p => p.Name == _request.PetName)), Times.Never);
        }


        [Fact]
        public async Task GivenIdNumberIsInvalid_WhenRescuePet_ThenThowsArgumentException()
        {
        //    //Arrange
        //    SetupHappyPath();

        //    _mockIdNumberValidator.Setup(x => x.Validate(It.IsAny<string>())).ReturnsAsync(false);

        //    //Act
        //    var exception = await Assert.ThrowsAsync<ArgumentException>(() => _petServiceSut.RescuePet(_request));

        //    exception.Message.Should().Be("CNP format is invalid");

        //    //Assert
        //    _mockPetRepository.Verify(x => x.Add(It.Is<Pet>(p => p.Name == _request.PetName)), Times.Never);
        }
    }
}