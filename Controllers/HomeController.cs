using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //GET
        public IActionResult Index()
        {
            var model = new FizzBuzzer();
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(FizzBuzzer input)
        {
            //Check to ensure both numbers entered are between 1 and 100
            if (input.NumFizz > 100 || input.NumBuzz > 100)
            {
                //swal("Unable to process", "Please enter a number in each box!", "error");
                input.FizzBuzz += "<b><font color='red'>Invalid Numbers!<br>Please enter a number between 1 and 100 in each box!</font></b>";
                return View(input);
            }

            if (input.NumFizz < 1 || input.NumBuzz < 1)
            {
                input.FizzBuzz += "<b><font color='red'>Invalid Numbers!<br>Please enter a number between 1 and 100 in each box!</font></b>";
                return View(input);
            }

            for (int k = 1; k < 101; k++)
            {
                // Check if both numbers mod to zero for FizzBuzz
                if ((k % input.NumFizz == 0) && (k % input.NumBuzz == 0))
                {
                    if (k == 100)
                    {
                        input.FizzBuzz += "<b><font color='red'>FizzBuzz</font></b>";
                    }
                    else
                    {
                        input.FizzBuzz += "<b><font color='red'>FizzBuzz</font></b>" + ", ";
                    }
                }
                // Check if only 1st number mods to zero - "Fizz"
                else if ((k % input.NumFizz == 0))
                {
                    if (k == 100)
                    {
                        input.FizzBuzz += "<b><i><font color='blue'>Fizz</font></i></b>";
                    }
                    else
                    {
                        input.FizzBuzz += "<b><i><font color='blue'>Fizz</font></i></b>" + ", ";
                    }
                }
                // Check if only 2nd number mods to zero - "Buzz"
                else if ((k % input.NumBuzz == 0))
                {
                    if (k == 100)
                    {
                        input.FizzBuzz += "<b><i><font color='orange'>Buzz</font></i></b>";
                    }
                    else
                    {
                        input.FizzBuzz += "<b><i><font color='orange'>Buzz</font></i></b>" + ", ";
                    }
                }
                else
                {
                    if (k == 0)
                    {
                        input.FizzBuzz += k;
                    }
                    input.FizzBuzz += k + ", ";
                }
            }
            return View(input);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
