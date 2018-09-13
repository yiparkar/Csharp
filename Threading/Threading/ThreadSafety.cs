using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class ThreadSafety
    {
        Dictionary<int, string> _employees = new Dictionary<int, string>();
        public void Execute()
        {
            Console.WriteLine("***************Thread Safety***********");
            var t1 = Task.Run(() => { addItem(1, "John Scott"); });
            var t2 = Task.Run(() => { addItem(2, "Sliver Night"); });
            var t3 = Task.Run(() => { addItem(3, "Nigel Timmon"); });
            var t4 = Task.Run(() => { addItem(4, "Sarah Parker"); });

            Task.WaitAll(t1, t2, t4, t3);
            
        }

        private void addItem(int key, string name)
        {
            lock(_employees)
            {
                Console.WriteLine("Lock taken by for writing : "  + Task.CurrentId);
                if(!_employees.ContainsKey(key))
                {
                    _employees.Add(key, name);
                }
                else
                {
                    Console.WriteLine("Employee Id already exists");
                }
            }
            Dictionary<int, string> dictionary;
            lock(_employees)
            {
                Console.WriteLine("Lock taken by for read : " + Task.CurrentId);
                dictionary = new  Dictionary<int, string>(_employees);
                
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("Id : " + item.Key + " Name : " + item.Value);
            }
        }
    }
}
