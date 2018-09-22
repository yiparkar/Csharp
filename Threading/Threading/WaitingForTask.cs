using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class WaitingForTask
    {
        public void Execute()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                Console.WriteLine("Process takes 5 secs");
                for(int i = 0;i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
            }, token);
            t.Start();

            Task t2 = Task.Run(() => { Thread.Sleep(3000); }, token);

            Task.WaitAny(t, t2);
            Console.WriteLine($"Task Status t is {t.Status}");
            Console.WriteLine($"Task Status t2 is {t2.Status}");
            //Task.WaitAny(new[] { t, t2 }, 3000);
            //Task.WaitAll(t, t2);
            Console.WriteLine("Waiting Done");
        }
    }
}
