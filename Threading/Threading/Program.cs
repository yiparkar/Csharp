using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    class Program
    {
        static void Main(string[] args)
        {
            //new ThreadSafety().Execute();
            //Console.WriteLine();
            //new AutoResetEventSignal().Execute();
            //Console.WriteLine();
            //new TwoWaySignaling().Execute();
            //Console.WriteLine();
            //new TaskCancellation().Execute();
            //new TaskCancellation().ExecuteMultipleCancellation();
            new ExceptionHandling().Execute();   
            Console.ReadLine();
        }
    }
}
