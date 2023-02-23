using DoNotTestImplementationDetails;
using Moq;
using Xunit;

namespace Tests
{
    public class CalculatorTests_Wrong
    {
        private readonly Calculator _calculatorSut;
        private readonly Mock<ISumService> _sumServiceMock;
        private readonly IMultiplyService _multitplyService;

        public CalculatorTests_Wrong()
        {            
            _sumServiceMock = new Mock<ISumService> ();

            _sumServiceMock.Setup (x => x.Add(It.IsAny<int>(), It.IsAny<int>()));

            _multitplyService = new MultiplyService(_sumServiceMock.Object);

            _calculatorSut = new Calculator(_sumServiceMock.Object, _multitplyService);
        }

        [Fact]
        public void GivenTwoNumbers_WhenSumIsCalled_CallsAddOnSumService()
        {
            //Arrange 
            int a = 5;
            int b = 10;

            //Act
            var result = _calculatorSut.Sum(a, b);

            //Assert
            _sumServiceMock.Verify(x => x.Add(It.Is<int>(x => x == a), It.Is<int>(y => y == b)), Times.Once);

        }

        [Fact]
        public void GivenTwoNumbers_WhenMultiplyIsCalled_CallsAddOnSumServiceMultipleTimes()
        {
            //Arrange 
            int a = 5;
            int b = 10;

            //Act
            var result = _calculatorSut.Multiply(a, b);

            //Assert
            _sumServiceMock.Verify(x => x.Add(It.IsAny<int>(), It.Is<int>(y => y == b)), Times.Exactly(a));
        }
    }
}
