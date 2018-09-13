using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class AutoResetEventSignal
    {
        //EventWaitHandle _eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        EventWaitHandle _autoresetEvent = new AutoResetEvent(false);
        public void Execute()
        {
            Console.WriteLine("***************Auto Reset Event Signal***********");
            
            Task.Run(() => WorkerItem());
            Task.Delay(2000);
            _autoresetEvent.Set();
            
        }

        private void WorkerItem()
        {
            Console.WriteLine("Waiting to enter the gate");
            _autoresetEvent.WaitOne();
            Console.WriteLine("Gate entered");
        }
    }
}
