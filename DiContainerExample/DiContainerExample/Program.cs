using Calculator.Implementation;
using StructureMap;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiContainerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new Container();
            container.Configure(r => r.AddRegistry(new CalculatorImplRegistry()));
            container.Configure(r => r.For<CalculationEngine>().Use<CalculationEngine>());

            var engine = container.GetInstance<CalculationEngine>();
            engine.CalculateMean();
            engine.CalculateFactorial();

            Console.ReadLine();
        }

        
    }
}
