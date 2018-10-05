using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingTuts
{
    class HackersCodeProblems
    {
        static void plusMinus(int[] arr)
        {
            int plusCount = 0;
            int minusCount = 0;
            int zeroCount = 0;
            int len = arr.Length;

            plusCount = arr.Where(r => r > 0).Count();
            minusCount = arr.Where(r => r < 0).Count();
            zeroCount = arr.Where(r => r == 0).Count();
            Console.WriteLine((decimal)plusCount / (decimal)len);
            Console.WriteLine((decimal)minusCount / (decimal)len);
            Console.WriteLine((decimal)zeroCount / (decimal)len);
        }
        static void minMaxSum()
        {
            int[] arr = new int[] { 256741038, 623958417, 467905213, 714532089, 938071625 };
            Array.Sort(arr);
            long minSum = 0;
            long maxSum = 0;
            for (int i = 0; i < 4; i++)
            {
                minSum += arr[i];
                maxSum += arr[arr.Length - i - 1];
            }
            Console.WriteLine(minSum + " " + maxSum);
        }
        static void staircase(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (n - 1 == j)
                    {
                        Console.WriteLine("#");
                    }
                    else if (i >= (n - j - 1))
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }
        static void test()
        {
            int i;
            int j = new int();
            i = 10;
            j = 20;
            string str1;
            str1 = i.ToString();
            str1 = j.ToString();
            int[] nums = { 1, -2, 3, 0, -4, 5 };
            int len = (from n in nums where n > 0 select n).Count();
            //myclass c = new myclass();
            //foreach(char ch in c)
            //{
            //    Console.Write(ch + " ");
            //}
            string[] strs = { "alpha", "beta", "gamma" };
            var chrs = from str in strs
                       let chrArray = str.ToCharArray()
                       from ch in chrArray
                       orderby ch
                       select ch;
            foreach (var c in chrs)
                Console.Write(c + " ");
            int a = 5;
            int b;
            m1(ref a);
            m2(out b);
            Console.WriteLine(a + " " + b);
        }

        static void m1(ref int x)
        {
            x = x + x;
        }
        static void m2(out int x)
        {
            x = 6;
            x = x * x;
        }
    }

    public class myclass
    {
        char[] chs = { 'A', 'B', 'C', 'D' };
        public System.Collections.IEnumerator GetEnumerator()
        {
            foreach (char ch in chs)
                yield return ch;
        }
    }
    public struct shs
    {
        public int i;
        public shs(int i)
        {
            this.i = i;
        }
    }
    public sealed class sss
    {
        public sss()
        {
            int i = 0;
            i = i * i;
        }
    }
    public abstract class asd
    {
        int i;
        public asd()
        {
            i = 100;
        }
    }
}

