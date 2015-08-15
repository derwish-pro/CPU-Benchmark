using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            int someNumber = 1;
            Profile("ArrayList.Add", 10, ArrayListAdd);
        }



        public static void ArrayListAdd()
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < 10000000; i++)
                al.Add("hello");
        }

        static void Profile(string description, int iterations, Action func)
        {
            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.Write(description);
            Console.WriteLine(" Time Elapsed {0} ms", watch.Elapsed.TotalMilliseconds);
            Console.ReadLine();
        }
    }
}
