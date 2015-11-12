using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminControl.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult EditOrder()
        {
            return View();
        }

        public ActionResult DeleteOrder()
        {
            return View();
        }
    }
}