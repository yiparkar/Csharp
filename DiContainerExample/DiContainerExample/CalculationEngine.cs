using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainerExample
{
    public class CalculationEngine
    {
        IMean<Int32> _meanCalc;
        IFactorial<int> _factCalc;
        public CalculationEngine(IMean<Int32> meanCalc, IFactorial<int> factCalc)
        {
            _meanCalc = meanCalc;
            _factCalc = factCalc;
        }
        public void CalculateMean()
        {
            List<int> num = new List<int>() { 5, 9, 4, 6, 3, 1 };
            Console.WriteLine("Mean of { 5, 9, 4, 6, 3, 1 } is :" + _meanCalc.Calculate(num));
        }

        public void CalculateFactorial()
        {
            Console.WriteLine("Factorial of 5 is :" + _factCalc.Calculate(5));
        }
    }
}
