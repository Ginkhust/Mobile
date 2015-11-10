using System.Web.Mvc;
using Parse;
using System.Threading.Tasks;
using AdminControl.Models;
using System.Collections.Generic;
using System.Collections;
using AdminControl.App_Start;

namespace AdminControl.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ProductController : BaseController
    {
        public async Task<ActionResult> ProductList()
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
                IEnumerable<ParseObject> products = await query.FindAsync();

                List<ProductViewModel> _products = new List<ProductViewModel>();

                foreach (ParseObject p in products)
                {
                    ProductViewModel product = new ProductViewModel(p);
                    Specification sp = new Specification(await p.Get<ParseObject>("specification").FetchIfNeededAsync());
                    product.setSpecification(sp);

                    _products.Add(product);
                }

                return View(_products);
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