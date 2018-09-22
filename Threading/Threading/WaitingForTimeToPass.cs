using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class WaitingForTimeToPass
    {
        public void Execute()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("You have 5  seconds to cancel the process");
                var cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "Process Cancelled" : "Process executed");
            },token);
            t.Start();
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine("Waiting Program Done");
        }
    }
}
