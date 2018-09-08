using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class AsynchornousProgrammingTest
    {
        async public void DisplayPrimeCount()
        {
            for(int i =0;i<10;i++)
            {
                Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) + " primes between ....");
            }
            Console.WriteLine("Done!");
        }
        void DisplayPrimeCountsFrom(int i)
        {

            var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult() + " primes between ....");
                if (i++ < 10) DisplayPrimeCountsFrom(i);
                else Console.WriteLine("Done!");
            }
            );
        }
        Task<int> GetPrimesCountAsync(int start,int count)
        {
            return Task.Run(() => ParallelEnumerable.Range(start, count).Count(n =>
                 Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
        }
    }
}
