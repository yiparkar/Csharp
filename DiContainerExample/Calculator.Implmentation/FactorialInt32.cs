using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Implementation
{
    public class FactorialInt32 : IFactorial<Int32>
    {
        public int Calculate(int value)
        {
            int fact = 1;
            for (int i = 1; i <= value; i++)
                fact *= i;

            return fact;
        }

        public int Calculate(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
