using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using CPU_Benchmark;

namespace ConsoleBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityBoostEnabled = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

            StartWhetstone();
            StartLinpack();
            Console.ReadKey();
        }


        private static void StartLinpack()
        {
            Console.WriteLine("Starting Linpak benchmark...");
            Console.WriteLine();

            double bestValue=0;
            double bestThreadsCount=0;

            Linpack lin = new Linpack();
            for (int i = 1; i <= 10; i++)
            {
                lin.RunBenchmark(i);
                Console.WriteLine(string.Format("Threads: {0}", i));
                Console.WriteLine(string.Format("Time: {0}", lin.TimeTotal));
                Console.WriteLine(string.Format("Mflop/s: {0}", lin.MFlopsTotal));
                Console.WriteLine(string.Format(""));

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }
            }

            for (int i = 50; i <= 200; i += 50)
            {
                lin.RunBenchmark(i);
                Console.WriteLine(string.Format("Threads: {0}", i));
                Console.WriteLine(string.Format("Time: {0}", lin.TimeTotal));
                Console.WriteLine(string.Format("Mflop/s: {0}", lin.MFlopsTotal));
                Console.WriteLine(string.Format(""));

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }
            }
            Console.WriteLine(string.Format("Best Mflop/s: {0} ({1} threads)", bestValue, bestThreadsCount));
            Console.WriteLine(string.Format("CPU Mark: {0}", (int)(bestValue*2.69)));
            Console.WriteLine();

            Console.WriteLine("Linpak benchmark complete.");
            Console.WriteLine();
        }

        private static void StartWhetstone()
        {
            Console.WriteLine("Starting Whetstone benchmark...");
            Console.WriteLine();

            Whetstone whet = new Whetstone();
            whet.ITERATIONS = 100; // ITERATIONS/10 = Millions Whetstone instructions
            whet.NumberOfCycles = 100;

            int numberOfRuns = 10;
            float elapsedTime = 0;
            float meanTime = 0;
            float rating = 0;
            float meanRating = 0;
            int intRating = 0;
            for (int runNumber = 1; runNumber <= numberOfRuns; runNumber++)
            {
                // Call the Whetstone benchmark procedure
                // compute elapsed time
                elapsedTime = (float)(whet.StartCalc() / 1000);
                Console.WriteLine(string.Format("{0}.Test (time for {1} cycles): {2} millisec.", runNumber, whet.NumberOfCycles, whet.EndTime - whet.BeginTime));
                // sum time in milliseconds per cycle
                meanTime = meanTime + (elapsedTime * 1000 / whet.NumberOfCycles);
                // Calculate the Whetstone rating based on the time for
                // the numbers of cycles just executed
                rating = (1000 * whet.NumberOfCycles) / elapsedTime;
                // Sum Whetstone rating
                meanRating = meanRating + rating;
                intRating = (int)rating;
                // Reset no_of_cycles for the next run using ten cycles more
                whet.NumberOfCycles += 10;
            }
            meanTime = meanTime / numberOfRuns;
            meanRating = meanRating / numberOfRuns;
            intRating = (int)meanRating;

            Console.WriteLine(string.Format("Number of Runs {0}", numberOfRuns));
            Console.WriteLine(string.Format("Average time per cycle {0} millisec.", meanTime));
            Console.WriteLine();
            Console.WriteLine(string.Format("Average Whetstone Rating {0} MWIPS", intRating / 1000));
            Console.WriteLine(string.Format("CPU Mark: {0}", (int)(intRating / 1000 * 13.1)));

            Console.WriteLine();
            Console.WriteLine("Whetstone benchmark complete.");
            Console.WriteLine();
        }
    }
}
