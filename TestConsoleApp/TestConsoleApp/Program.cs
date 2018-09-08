using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            callEAPTest();
            Console.ReadLine();
        }
        static void callEAPTest()
        {
            EAPSample obj = new EAPSample();
            obj.Execute();
        }
        static void callAsyncTest()
        {
            AsynchornousProgrammingTest obj = new AsynchornousProgrammingTest();
            obj.DisplayPrimeCount();
        }
        static void callTasCompSource()
        {
            TaskCompletionSourceTest obj = new TaskCompletionSourceTest();
            Console.WriteLine("Simple TaskCompletionSource");
            obj.Execute();
            Console.WriteLine("Continuation TaskCompletionSource");
            obj.WithContinuation();
        }
    }
}
