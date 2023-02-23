namespace DoNotTestImplementationDetails
{
    public class Calculator
    {
        private readonly ISumService _sumService;
        private readonly IMultiplyService _multiplyService;

        public Calculator(ISumService sumService, IMultiplyService multiplyService)
        {
            _multiplyService = multiplyService;
            _sumService = sumService;   
        }
        public int Sum(int x, int y)
        {
            return _sumService.Add(x, y);
        }

        public int Multiply(int x, int y)
        {
            return _multiplyService.Multiply(x, y);
        }
    }
}
