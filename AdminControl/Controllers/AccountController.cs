using Parse;
using System.Collections.Generic;
using AdminControl.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.Threading.Tasks;
using AdminControl.Provider;
using AdminControl.App_Start;
using System;
using System.Web;

namespace AdminControl.Controllers
{
    public class AccountController : Controller
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

                if (model.rememberMe)
                {
                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        username,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(20), // expiry
                        model.rememberMe,
                        "/"
                    );
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                }

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

        public async Task<ActionResult> Profiles()
        {
            if (Session["login"] != null && ParseUser.CurrentUser != null)
            {
                UserViewModel currentUser = new UserViewModel();
                var user = await ParseUser.Query.WhereEqualTo("type", 1).GetAsync(ParseUser.CurrentUser.ObjectId);

                currentUser.userId = user.ObjectId;
                currentUser.username = user.Get<string>("username");
                currentUser.firstName = user.Get<string>("firstName");
                currentUser.lastName = user.Get<string>("lastName");
                currentUser.phoneNumber = user.Get<string>("phoneNumber");
                currentUser.address = user.Get<string>("address");
                currentUser.birthday = user.Get<DateTime>("birthday");
                currentUser.email = user.Get<string>("email");
                currentUser.gender = user.Get<string>("gender");
                currentUser.role = user.Get<string>("role");

                return View(currentUser);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Profiles(FormCollection form)
        {
            if (Session["login"] != null && ParseUser.CurrentUser != null)
            {
                var user = await ParseUser.Query.WhereEqualTo("type", 1).GetAsync(ParseUser.CurrentUser.ObjectId);
                user.Username = form["username"].ToString();
                user.Password = form["password"].ToString();
                user.Email = form["email"].ToString();
                user["firstName"] = form["firstName"].ToString();
                user["lastName"] = form["firstName"].ToString();
                user["phoneNumber"] = form["phoneNumber"];
                user["address"] = form["address"].ToString();
                user["birthday"] = DateTime.Parse(form["birthday"].ToString());
                user["gender"] = form["gender"].ToString();
                user["role"] = form["role"].ToString();

                await user.SaveAsync();
            }
            return RedirectToAction("CustomerList", "Customer");
        }

        public ActionResult Logout()
        {
            Session["login"] = null;
            ParseUser.LogOut();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}