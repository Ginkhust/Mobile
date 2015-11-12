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
    public class ProductController : Controller
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

                    // Get specification from product
                    Specification sp = new Specification(await p.Get<ParseObject>("specification").FetchIfNeededAsync());

                    // Add specification into product model
                    product.setSpecification(sp);

                    _products.Add(product);
                }

                return View(_products);
            }
            catch (ParseException)
            {
                return View();
            }
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductSpecificationModel model)
        {
            try
            {
                IList<string> slide = new List<string>();
                
                if (ModelState.IsValid)
                {
                    ParseObject specification = new ParseObject("Specification");
                    specification["screen"] = model.Specification.screen;
                    specification["frontCamera"] = model.Specification.frontCamera;
                    specification["backCamera"] = model.Specification.backCamera;
                    specification["os"] = model.Specification.os;
                    specification["chipset"] = model.Specification.chipset;
                    specification["cpu"] = model.Specification.cpu;
                    specification["ram"] = model.Specification.ram;
                    specification["interalStorage"] = model.Specification.internalStorage;
                    specification["sdcard"] = model.Specification.sdcard;
                    specification["simNumber"] = model.Specification.simNumber;
                    specification["batery"] = model.Specification.batery;
                    specification["connection"] = model.Specification.connection;

                    await specification.SaveAsync();

                    ParseObject product = new ParseObject("Product");
                    product["name"] = model.ProductModel.name;
                    product["price"] = model.ProductModel.price;
                    product["quantity"] = model.ProductModel.quantity;
                    product["manufacture"] = model.ProductModel.manufacture;
                    product["salePrice"] = model.ProductModel.salePrice;
                    product["oldPrice"] = model.ProductModel.oldPrice;
                    product["thumbnailImage"] = model.ProductModel.thumbnailImage;
                    product["smallSlideImage"] = model.ProductModel.smallSlideImage;
                    product["specification"] = specification;

                    await product.SaveAsync();
                    return RedirectToAction("ProductList");

                }
                else
                {
                    ModelState.AddModelError("", "Input is invalid");
                    return View();
                }

            }
            catch (ParseException)
            {
                return View();
            }
            
        }

        public async Task<ActionResult> EditProduct(string id)
        {
            try
            {
                ParseQuery<ParseObject> query = ParseObject.GetQuery("Product");
                ParseObject product = await query.GetAsync(id);

                ProductViewModel _product = new ProductViewModel(product);
                Specification _specification = new Specification(await product.Get<ParseObject>("specification").FetchIfNeededAsync());
                ProductSpecificationModel model = new ProductSpecificationModel();
                model.ProductModel = _product;
                model.Specification = _specification;

                return View(model);
            }
            catch (ParseException)
            {
                return View();
            }
            
        }

        [HttpPost]
        public async Task<ActionResult> EditProduct(string id, ProductSpecificationModel model)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    ParseQuery<ParseObject> queryS = ParseObject.GetQuery("Specification");
                    ParseObject specification = await queryS.GetAsync(model.Specification.specificationId);
                    specification["screen"] = model.Specification.screen;
                    specification["frontCamera"] = model.Specification.frontCamera;
                    specification["backCamera"] = model.Specification.backCamera;
                    specification["os"] = model.Specification.os;
                    specification["chipset"] = model.Specification.chipset;
                    specification["cpu"] = model.Specification.cpu;
                    specification["ram"] = model.Specification.ram;
                    specification["interalStorage"] = model.Specification.internalStorage;
                    specification["sdcard"] = model.Specification.sdcard;
                    specification["simNumber"] = model.Specification.simNumber;
                    specification["batery"] = model.Specification.batery;
                    specification["connection"] = model.Specification.connection;

                    await specification.SaveAsync();

                    ParseQuery<ParseObject> queryP = ParseObject.GetQuery("Product");
                    ParseObject product = await queryP.GetAsync(id);
                    product["name"] = model.ProductModel.name;
                    product["price"] = model.ProductModel.price;
                    product["quantity"] = model.ProductModel.quantity;
                    product["manufacture"] = model.ProductModel.manufacture;
                    product["salePrice"] = model.ProductModel.salePrice;
                    product["oldPrice"] = model.ProductModel.oldPrice;
                    product["thumbnailImage"] = model.ProductModel.thumbnailImage;
                    model.ProductModel.smallSlideImage = new List<string>();
                    product.AddRangeToList("smallSlideImage", model.ProductModel.smallSlideImage);

                    await product.SaveAsync();

                }
                else
                {
                    ModelState.AddModelError("", "Error input valid");
                    return View();
                }

            }
            catch (ParseException)
            {
                return View();
            }
            return RedirectToAction("ProductList");
        }


        public async Task<ActionResult> DeleteProduct(string id)
        {
            try
            {
                ParseQuery<ParseObject> queryP = ParseObject.GetQuery("Product");
                ParseObject product = await queryP.GetAsync(id);
                await product.DeleteAsync();

                return RedirectToAction("ProductList");
            }
            catch (ParseException e)
            {
                ViewBag.Error = "Error on server, detail: " + e.Message;
                return RedirectToAction("Error");
            }

        }
    }
}