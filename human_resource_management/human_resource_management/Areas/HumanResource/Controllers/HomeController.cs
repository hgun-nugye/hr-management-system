using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace human_resource_management.Areas.HumanResource.Controllers
{
    public class HomeController : Controller
    {
        // GET: HumanResource/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerEmployee()
        {
            return View();
        }
        public ActionResult Salary()
        {
            return View();
        }
        public ActionResult Statistical()
        {
            return View();
        }

    }
}