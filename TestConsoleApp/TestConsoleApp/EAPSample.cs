using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class EAPSample
    {
        BackgroundWorker _worker;
        public EAPSample()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }
        public void Execute()
        {
            _worker.RunWorkerAsync();
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("Cancelled");
            else
                Console.WriteLine("Result is : " + e.Result);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Task.Delay(1000);
            Console.WriteLine("Work Done!");
            e.Result = 10;
        }
    }
}
