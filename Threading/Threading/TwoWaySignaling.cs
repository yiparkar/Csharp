using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class TwoWaySignaling
    {
        AutoResetEvent _first = new AutoResetEvent(false);
        AutoResetEvent _second = new AutoResetEvent(false);
        object _lock = new object();
        string _value = string.Empty;
        public void Execute()
        {
            Console.WriteLine("***************Two way Signal***********");
            Task.Run(() => WorkerThread());
            Console.WriteLine("Waiting for worker");
            _first.WaitOne();            
            Thread.Sleep(2000);
            lock (_lock)
            {
                _value = "Updating in Main";
                Console.WriteLine(_value);
            }
            _second.Set();
            Console.WriteLine("Release Worker");
        }

        private void WorkerThread()
        {
            Thread.Sleep(2000);
            lock (_lock)
            {
                _value = "Updating in worker";
                Console.WriteLine(_value);
            }
            _first.Set();
            Console.WriteLine("Release Main");
            Console.WriteLine("Waiting for Main");
            _second.WaitOne();
        }
    }
}
