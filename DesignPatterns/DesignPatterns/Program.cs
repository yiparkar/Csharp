using DesignPatterns.OCPrinciple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var ocp = new OpenClosePrincipleDemo();
            ocp.Execute();
            Console.ReadLine();
        }
    }
}
