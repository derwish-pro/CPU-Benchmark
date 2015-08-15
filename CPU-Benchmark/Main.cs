using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CPU_Benchmark
{
    public partial class Main : Form
    {
        public Main()
        {
            Process.GetCurrentProcess().PriorityBoostEnabled = true;
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            InitializeComponent();
        }

        private async void btnStartLinpack_Click(object sender, EventArgs e)
        {
            listBoxLinpack.Items.Clear();

            double bestValue = 0;
            double bestThreadsCount = 0;

            Linpack lin = new Linpack();
            for (int i = 1; i <= 10; i++)
            {
                lin.RunBenchmark(i);
                listBoxLinpack.Items.Add(string.Format("Threads: {0}", i));
                listBoxLinpack.Items.Add(string.Format("Time: {0}", lin.TimeTotal));
                listBoxLinpack.Items.Add(string.Format("Mflop/s: {0}", lin.MFlopsTotal));
                listBoxLinpack.Items.Add(string.Format(""));

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }

                //scrool down
                int visibleItems = listBoxLinpack.ClientSize.Height / listBoxLinpack.ItemHeight;
                listBoxLinpack.TopIndex = Math.Max(listBoxLinpack.Items.Count - visibleItems + 1, 0);

                //refrash ui
                listBoxLinpack.Refresh();

            }

            for (int i = 50; i <= 200; i+=50)
            {
                lin.RunBenchmark(i);
                listBoxLinpack.Items.Add(string.Format("Threads: {0}", i));
                listBoxLinpack.Items.Add(string.Format("Time: {0}", lin.TimeTotal));
                listBoxLinpack.Items.Add(string.Format("Mflop/s: {0}", lin.MFlopsTotal));
                listBoxLinpack.Items.Add(string.Format(""));

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }

                //scrool down
                int visibleItems = listBoxLinpack.ClientSize.Height / listBoxLinpack.ItemHeight;
                listBoxLinpack.TopIndex = Math.Max(listBoxLinpack.Items.Count - visibleItems + 1, 0);

                //refrash ui
                listBoxLinpack.Refresh();


            }

            listBoxLinpack.Items.Add(string.Format("Best Mflop/s: {0} ({1} threads)", bestValue, bestThreadsCount));
            listBoxLinpack.Items.Add(string.Format("CPU Mark: {0}", (int)(bestValue * 2.69)));

            //scrool down
            int it = listBoxLinpack.ClientSize.Height / listBoxLinpack.ItemHeight;
            listBoxLinpack.TopIndex = Math.Max(listBoxLinpack.Items.Count - it + 1, 0);
            listBoxLinpack.Refresh();
       }

        private void btnStartWhetstone_Click(object sender, EventArgs e)
        {
            listBoxWhetstone.Items.Clear();

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
                this.listBoxWhetstone.Items.Add(string.Format("{0}.Test (time for {1} cycles): {2} millisec.", runNumber, whet.NumberOfCycles, whet.EndTime - whet.BeginTime));
                this.listBoxWhetstone.Refresh();
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

            this.listBoxWhetstone.Items.Add(string.Format("Number of Runs {0}", numberOfRuns));
            this.listBoxWhetstone.Items.Add(string.Format("Average time per cycle {0} millisec.", meanTime));
            this.listBoxWhetstone.Items.Add(string.Format("Average Whetstone Rating {0} KWIPS", intRating));
            this.listBoxWhetstone.Items.Add(string.Format("Average Whetstone Rating {0} MWIPS", intRating / 1000));
        }
    }
}
