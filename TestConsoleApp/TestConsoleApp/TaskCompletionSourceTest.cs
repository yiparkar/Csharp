using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class TaskCompletionSourceTest
    {
        public void Execute()
        {
            var tcs = new TaskCompletionSource<int>();
            new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); }).Start();
            Task<int> task = tcs.Task;
            Console.WriteLine(task.Result);
        }
        public void WithContinuation()
        {
            var awaiter = GetAnswerToLife().GetAwaiter();
            Console.WriteLine(awaiter.GetResult());
        }

        private Task<int> GetAnswerToLife()
        {
            var tcs = new TaskCompletionSource<int>();
            var timer = new System.Timers.Timer(5000) { AutoReset = false };
            timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
            timer.Start();
            return tcs.Task;
        }
    }
}
