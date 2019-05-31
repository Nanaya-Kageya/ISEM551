using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assignment.Models;
using assignment.Business;
using System.Collections.Generic;

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
            ViewBag.TaskMessage = "View Tasks in this page.";
            return View();
        }

        public IActionResult TasksManage()
        {
            var displayTasks = TaskService.GetIndividualTasks();

            ViewBag.TaskMessage = "Manage Tasks in this page.";

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

        [HttpPost]
        public IActionResult AddTasks()
        {
            Console.WriteLine("=====> Adding Tasks Controller start...");

            var tasksRequest = new List<TaskVO>();

            for (int i = 1; i < 9; i++)
            {
                TaskVO task = new TaskVO
                {
                    firstName = Request.Form["firstname" + i],
                    lastName = Request.Form["lastname" + i],
                    task = Request.Form["task" + i],
                    status = Request.Form["status" + i]
                };

                Console.WriteLine("=====> Getting Firstname :: " + task.firstName);
                Console.WriteLine("=====> Getting Lastname :: " + task.lastName);
                Console.WriteLine("=====> Getting Task :: " + task.task);
                Console.WriteLine("=====> Getting Status :: " + task.status);
                tasksRequest.Add(task);
                Console.WriteLine("========= Added New TaskVO =========");
            }

            TaskService.SaveTask(tasksRequest);

            var displayTasks = TaskService.GetIndividualTasks();

            ViewBag.TaskMessage = "Manage Tasks in this page.";

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
