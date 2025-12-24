using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace human_resource_management.Areas.Employee.Controllers
{
    public class HomeController : Controller
    {
        // GET: Employee/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}