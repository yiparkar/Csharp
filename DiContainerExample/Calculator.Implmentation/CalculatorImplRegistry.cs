using Calculator.Interface;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Implementation
{
    public class CalculatorImplRegistry : Registry
    {
        public CalculatorImplRegistry()
        {
            For<IMean<Int32>>().Use<MeanInt32>();
            For<IFactorial<Int32>>().Use<FactorialInt32>();
        }
    }
}
