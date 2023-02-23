using DoNotTestImplementationDetails;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class CalculatorTests_Correct
    {
        private readonly Calculator _calculatorSut;
        private readonly ISumService _sumService;
        private readonly IMultiplyService _multitplyService;

        public CalculatorTests_Correct()
        {            
            _sumService = new SumService();

            _multitplyService = new MultiplyService(_sumService);

            _calculatorSut = new Calculator(_sumService, _multitplyService);
        }

        [Fact]
        public void GivenTwoNumbers_WhenSum_AddsTheNumbers()
        {
            //Arrange 
            int a = 5;
            int b = 10;
            int correctResult = 15;

            //Act
            var result = _calculatorSut.Sum(a, b);

            //Assert
            result.Should().Be(correctResult);

        }

        [Fact]
        public void GivenTwoNumbers_WhenMultiply_MultipliesTheNumbers()
        {
            //Arrange 
            int a = 5;
            int b = 10;
            int correctResult = 50;

            //Act
            var result = _calculatorSut.Multiply(a, b);

            //Assert
            result.Should().Be(correctResult);
        }
    }
}
