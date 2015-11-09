using Parse;
using System.Web.Mvc;

namespace AdminControl.Controllers
{
    
    public class DashBoardController : Controller
    {
        // GET: DashBoard Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();  
        }

        // GET: DashBoard Manager
        [Authorize(Roles = "Manager")]
        public ActionResult Manager()
        {
            return View();
        }

        // GET: DashBoard Shipper
        [Authorize(Roles ="Shipper")]
        public ActionResult Shipper()
        {
            return View();
        }
    }
}