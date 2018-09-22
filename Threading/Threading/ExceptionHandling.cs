using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class ExceptionHandling
    {
        public void Execute()
        {
            try
            {
                Test();
            }
            catch (AggregateException ae)
            {

                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine("Handled Else where " + e.Message);
                }
            }

            Console.WriteLine("Exception handling program done");
        }

        private static void Test()
        {
            Task t = Task.Run(() =>
            {
                throw new InvalidOperationException("Cant do this") { Source = "t" };
            });
            Task t2 = Task.Run(() =>
            {
                throw new ArgumentNullException("Cant do this") { Source = "t2" };
            });
            try
            {
                Task.WaitAll(t, t2);
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if(e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Unhandled!");
                        return false;
                    }
                });
                //foreach (var e in ae.InnerExceptions)
                //{
                //    Console.WriteLine(e.Message);
                //}
            }
        }
    }
}
