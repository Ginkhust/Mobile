using System.Web.Mvc;
using Parse;
using System.Threading.Tasks;
using AdminControl.Models;
using System.Collections.Generic;
using System.Collections;

namespace AdminControl.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ProductController : Controller
    {
        public async Task<ActionResult> ProductList()
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
                IEnumerable<ParseObject> productList = await query.FindAsync();

                List<ProductViewModel> _productList = new List<ProductViewModel>();

                foreach (ParseObject p in productList)
                {

                    ProductViewModel model = new ProductViewModel(p);
                    ParseQuery<ParseObject> q = ParseObject.GetQuery("Specification");
                    ParseObject specification = await q.GetAsync(model.specification.specificationId);
                    
                }

                return View();
            }
            catch (ParseException pe)
            {
                return View();
            }
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(FormCollection form)
        {
            try
            {
                ParseObject spec = new ParseObject("Specification");
                spec[""]
            }
            catch (ParseException pe)
            {

            }
            return RedirectToAction("ProductList");
        }

        public ActionResult EditProduct(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProduct(string id, FormCollection form)
        {
            return RedirectToAction("ProductList");
        }


        public ActionResult DeleteProduct(string id)
        {
            return RedirectToAction("ProductList");
        }
    }
}