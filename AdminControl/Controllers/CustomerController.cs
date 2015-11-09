using System;
using Parse;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminControl.Models;
using System.Threading.Tasks;
using System.Web.Security;

namespace AdminControl.Controllers
{
    
    public class CustomerController : Controller
    {
        [Authorize(Roles = "Admin, Manager, Shipper")]
        public async Task<ActionResult> CustomerList()
        {
            // Get query IEnumerable ParseUser
            var customers = await ParseUser.Query.WhereEqualTo("type", 0).FindAsync();

            List<UserViewModel> customerModels = new List<UserViewModel>();

            foreach (ParseUser p in customers)
            {
                UserViewModel customer = new UserViewModel();
                customer.userId = p.ObjectId;
                customer.username = p.Get<string>("username");
                customer.firstName = p.Get<string>("firstName");
                customer.lastName = p.Get<string>("lastName");
                customer.phoneNumber = p.Get<string>("phoneNumber");
                customer.address = p.Get<string>("address");
                customer.birthday = p.Get<DateTime>("birthday");
                customer.email = p.Get<string>("email");
                customer.isMale = p.Get<bool>("gender");
                customer.role = p.Get<string>("role");

                // Add user model into list 
                customerModels.Add(customer);
            }

            return View(customerModels);
        }

        [Authorize(Roles = "Admin, Manager")]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            var user = await ParseUser.Query.WhereEqualTo("type", 0).GetAsync(id);
            await user.DeleteAsync();
            return RedirectToAction("CustomerList");
        }
    }
}