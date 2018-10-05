using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    public class ConcurrentCollections
    {
        public void Execute()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);
            stack.Push(400);
            stack.Push(500);
            stack.Push(600);
            int res = 0;
            if (stack.TryPeek(out res))
                Console.WriteLine($"Peek element {res}");
            if (stack.TryPop(out res))
                Console.WriteLine($"Popped element {res}");
            int[] items = new int[2];
            if (stack.TryPopRange(items, 0, 2) > 0)
            {
                Console.Write("Popped Ranged elements");
                foreach (var i in items)
                    Console.Write($" {i}");
            }
            Console.WriteLine();
            Console.WriteLine("***Parallel Thread Stack Example****");
            int errorCount = 0;
            stack = new ConcurrentStack<int>();

            stack.PushRange(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            stack.PushRange(new int[] { 8, 9, 10 });
            stack.PushRange(new int[] { 11, 12, 13, 14 });
            stack.PushRange(new int[] { 15, 16, 17, 18, 19, 20 });
            stack.PushRange(new int[] { 21, 22 });
            stack.PushRange(new int[] { 23, 24, 25, 26, 27, 28, 29, 30 });

            Parallel.For(0, 10, i =>
              {
                  int[] range = new int[3];
                  if(stack.TryPopRange(range) != 3)
                  {
                      Console.WriteLine("Try pop failed unexpectedly");
                      Interlocked.Increment(ref errorCount);
                  }
                  // Each range should be consecutive integers, if the range was extracted atomically
                  // And it should be reverse of the original order...
                  var a1 = range.Skip(1);
                  var a2 = range.Take(range.Length - 1);
                  foreach (var e in a1)
                  {
                      Console.WriteLine($"{Task.CurrentId} - {e} a1");
                  }
                  foreach (var e in a2)
                  {
                      Console.WriteLine($"{Task.CurrentId} - {e} a2");
                  }
                  if (!range.Skip(1).SequenceEqual(range.Take(range.Length - 1).Select(x => x - 1)))
                  {
                      Console.WriteLine("CS: Expected consecutive ranges.  range[0]={0}, range[1]={1}", range[0], range[1]);
                      Interlocked.Increment(ref errorCount);
                  }
              });

            if (!stack.IsEmpty)
            {
                Console.WriteLine("CS: Expected IsEmpty to be true after emptying");
                errorCount++;
            }

            if (errorCount == 0) Console.WriteLine("  OK!");
        }
        ConcurrentDictionary<string, string> keyValuePairs = 
                                new ConcurrentDictionary<string, string>();
        public void AddElement(string key, string value)
        {
            bool success = keyValuePairs.TryAdd(key, value);

            var who = Task.CurrentId.HasValue ? $"{Task.CurrentId} task" : "Main Thread";
            Console.WriteLine($"{who} {(success ? " added" : " not added")} the element");
        }
        public void ExecuteDictionary()
        {
            AddElement("France", "Paris");
            Task.Run(() => { AddElement("France", "Paris"); }).Wait();

            keyValuePairs["Russia"] = "Leningard";
            var s = keyValuePairs.AddOrUpdate("Russia", "Moscow", (k, old) => old + " --> Moscow");

            keyValuePairs["Sweden"] = "Uppsala";
            var capOfSwe = keyValuePairs.GetOrAdd("Sweden", "Stockholm");
            Console.WriteLine($"Capital of Sweden is {capOfSwe}");

            const string toBeRemoved = "India";
            string capOfIn = "";
            var res = keyValuePairs.TryRemove(toBeRemoved, out capOfIn);
            if(res)
            {
                Console.WriteLine($"Removed element {toBeRemoved} with capital {capOfIn}");
            }
            else
            {
                Console.WriteLine($"Failed to remove element {toBeRemoved}");
            }

            Console.WriteLine($"The ");
            foreach (var kv in keyValuePairs)
            {
                Console.WriteLine($" - {kv.Value} is the capital of {kv.Key}");
            }

        }
    }
    

}

