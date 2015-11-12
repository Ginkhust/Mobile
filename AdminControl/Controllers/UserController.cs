using System;
using Parse;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdminControl.Models;
using AdminControl.App_Start;

namespace AdminControl.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        public async Task<ActionResult> UserList()
        {
            try
            {
                // Get query IEnumerable ParseUser
                var users = await ParseUser.Query.WhereEqualTo("type", 1).FindAsync();

                List<UserViewModel> userModels = new List<UserViewModel>();

                foreach (ParseUser p in users)
                {
                    if (p.Get<string>("username") == Session["login"].ToString())
                    {
                        continue;
                    }
                    UserViewModel user = new UserViewModel();
                    user.userId = p.ObjectId;
                    user.username = p.Get<string>("username");
                    user.firstName = p.Get<string>("firstName");
                    user.lastName = p.Get<string>("lastName");
                    user.phoneNumber = p.Get<string>("phoneNumber");
                    user.address = p.Get<string>("address");
                    user.birthday = p.Get<DateTime>("birthday");
                    user.email = p.Get<string>("email");
                    user.gender = p.Get<string>("gender");
                    user.role = p.Get<string>("role");

                    // Add user model into list 
                    userModels.Add(user);
                }

                return View(userModels);
            }
            catch (ParseException pe)
            {
                ViewBag.Error = pe.Message;
                return RedirectToAction("Error");
            }
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(FormCollection form)
        {
            try
            {
                var user = new ParseUser()
                {
                    Username = form["username"],
                    Password = form["password"],
                    Email = form["email"]
                };

                user["firstName"] = form["firstName"].ToString();
                user["lastName"] = form["lastName"].ToString();
                user["phoneNumber"] = form["phoneNumber"].ToString();
                user["address"] = form["address"].ToString();
                user["birthday"] = DateTime.Parse(form["birthday"].ToString());
                user["gender"] = bool.Parse(form["gender"]);
                user["role"] = form["role"].ToString();

                await user.SaveAsync();
                return RedirectToAction("UserList");
            }
            catch (ParseException pe)
            {
                ViewBag.Error = "Error input form " + pe.Message + " ! Please retry";
                return View();
            }
        }

        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                var user = await ParseUser.Query.WhereEqualTo("type", 1).GetAsync(id);
                await user.DeleteAsync();
                return RedirectToAction("UserList");
            }
            catch (ParseException pe)
            {
                ViewBag.Error = "Error while deleting" + pe.Message;
                return RedirectToAction("Error");
            }

        }

        public ActionResult Error()
        {
            return View();
        }
    }
}