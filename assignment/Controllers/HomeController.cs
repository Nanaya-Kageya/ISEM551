using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using assignment.Models;
using assignment.Business;

namespace assignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            //ViewData["TaskMessage"] = "Manage Tasks in this page.";
            ViewBag.TaskMessage = "Manage Tasks in this page.";
            return View();
        }

        public IActionResult TasksDisplay()
        {
            var displayTasks = TaskService.GetIndividualTasks();

            ViewBag.Task1 = displayTasks[0];
            ViewBag.Task2 = displayTasks[1];
            ViewBag.Task3 = displayTasks[2];
            ViewBag.Task4 = displayTasks[3];
            ViewBag.Task5 = displayTasks[4];
            ViewBag.Task6 = displayTasks[5];
            ViewBag.Task7 = displayTasks[6];
            ViewBag.Task8 = displayTasks[7];


            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
