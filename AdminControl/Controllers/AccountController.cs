using Parse;
using System.Collections.Generic;
using AdminControl.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using AdminControl.Provider;
using AdminControl.App_Start;

namespace AdminControl.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public static List<Role> roles = new List<Role>();
        public ActionResult Index()
        {
            return View();
        }

        // Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var username = model.username;
            var password = model.password;
            try
            {
                var user = await ParseUser.LogInAsync(username, password);
                if (user != null)
                {
                    GetUser getUser = new GetUser();
                    var role = user.Get<string>("role");
                    roles.AddRange(await getUser.GetRoleOfUser(username));
                    Session["login"] = username;
                    FormsAuthentication.SetAuthCookie(username, false);
                    return RedirectToAction(role.ToString(), "DashBoard");
                }

                ViewBag.Message = "Login Failed";
                return View();
            }
            catch (ParseException nre)
            {
                ViewBag.Message = "Login Failed, cause: " + nre.Message;
                return View();
            }

        }

        public ActionResult GetUserName()
        {
            return Content(Session["login"].ToString());
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel user)
        {
            return View();
        }

        public List<Role> getRole()
        {
            if (roles != null)
            {
                return roles;
            }
            return null;
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}