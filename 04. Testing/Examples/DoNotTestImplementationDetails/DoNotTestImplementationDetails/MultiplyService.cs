using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNotTestImplementationDetails
{
    public class MultiplyService : IMultiplyService
    {
        private readonly ISumService _sumService;
        public MultiplyService(ISumService sumService)
        {
            _sumService = sumService;
        }

        public int Multiply(int x, int y)
        {
            var result = 0;
            for (int i = 0; i < x; i++)
            {
                result = _sumService.Add(result, y);
            }

            return result;
        }
    }
}
