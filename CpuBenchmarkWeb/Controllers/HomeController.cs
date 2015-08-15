using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPU_Benchmark;

namespace CpuBenchmarkWeb2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            double bestValue = 0;
            double bestThreadsCount = 0;

            Linpack lin = new Linpack();
            for (int i = 1; i <= 10; i++)
            {
                lin.RunBenchmark(i);

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }
            }

            for (int i = 50; i <= 100; i += 50)
            {
                lin.RunBenchmark(i);

                if (lin.MFlopsTotal > bestValue)
                {
                    bestValue = lin.MFlopsTotal;
                    bestThreadsCount = i;
                }
            }

           



            ViewBag.Result = (int)(bestValue * 2.69);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}