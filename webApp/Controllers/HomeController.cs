using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Business;

namespace testWebApp.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    var mvcName = typeof(Controller).Assembly.GetName();
        //    var isMono = Type.GetType("Mono.Runtime") != null;

        //    ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
        //    ViewData["Runtime"] = isMono ? "Mono" : ".NET";

        //    return View();
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Tasks()
        {
            //ViewData["TaskMessage"] = "Manage Tasks in this page.";
            ViewBag.TaskMessage = "Manage Tasks in this page.";
            return View();
        }

        public ActionResult SaveInfo()
        {
            //ViewData["TaskMessage"] = "Manage Tasks in this page.";
            Console.WriteLine("This is a test");
            return View();
        }

        public ActionResult DisplayTasks()
        {
            //MySQlHelper h = new MySQlHelper();
            //string sql = "select * from users";
            //DataTable ds = h.ExecuteQuery(sql, CommandType.Text);
            ////DataSet ds = h.ExecuteDataset(sql);
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
            var displayTasks = TaskService.GetIndividualTasks();

            return View(displayTasks);
        }
    }
}
