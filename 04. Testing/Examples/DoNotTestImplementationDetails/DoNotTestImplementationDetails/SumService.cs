using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoNotTestImplementationDetails
{
    public class SumService : ISumService
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
}
