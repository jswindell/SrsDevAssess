using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SrsSoftDevelopmentAssessment.Part1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Q3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Q3(string sentence)
        {
            if (String.IsNullOrWhiteSpace(sentence))
                return View();

            // HACK: could have been achieved with words.Reverse()
            List<string> wordsReversed = new List<string>();
            foreach (string word in sentence.Split(' '))
                wordsReversed.Insert(0, word);

            return View(wordsReversed);
        }

        public ActionResult Q4()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Q4(string number)
        {
            int num;
            if (!Int32.TryParse(number, out num) || num < 1 || num > 1000)
                return View(num);

            int sum = 0;
            for (int i = 1; i < num; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }

            return View(sum);
        }
    }
}
