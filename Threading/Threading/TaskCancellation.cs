using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class TaskCancellation
    {
        public void Execute()
        {
            Console.WriteLine("***************TaskCancellation***********");
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() => {
                int i = 0;
                while(true)
                {
                    //token.ThrowIfCancellationRequested();
                    //Alternate way
                    //if (token.IsCancellationRequested)
                    //{
                    //    throw new OperationCanceledException();
                    //}
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                    else
                        Console.WriteLine($"Count:{i++}");
                    Thread.Sleep(300);
                }
            },token);
            t.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine(" IsCancellationRequested Program Done");


            cts = new CancellationTokenSource();
            token = cts.Token;
            token.Register(() =>
            {
                Console.WriteLine("Cancellation Request");
            });
            Task t2 = new Task(() => {
                int i = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine($"Count:{i++}");
                    Thread.Sleep(300);
                }
            }, token);
            t2.Start();

            Task.Run(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Waithandle was released, so cancellation was requested.");
            });
            Console.ReadKey();
            cts.Cancel();
            Console.WriteLine(" ThrowIfCancellationRequested, WaitHandler and Register Event Program Done");
        }

        public void ExecuteMultipleCancellation()
        {
            var planned = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();

            var paranoid = CancellationTokenSource.CreateLinkedTokenSource(planned.Token
                , preventative.Token, emergency.Token);

            Task.Run(() => {
                int i = 0;
                while(true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}");
                    Thread.Sleep(200);
                }
            },paranoid.Token);
            Console.ReadKey();
            emergency.Cancel();

            Console.WriteLine("Cancellation Request");
        }
    }
}
