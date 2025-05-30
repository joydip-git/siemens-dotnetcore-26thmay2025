using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.UserInterface.Models;

namespace ProductManagementSystem.UserInterface.Controllers
{
    public class ProductController(IProductManager manager, ILogger<ProductController> logger) : Controller
    {
        private readonly IProductManager _manager = manager;
        private readonly ILogger<ProductController> _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute(Name = "id")] string message)
        {
            try
            {
                List<ProductViewModel>? products = await _manager.SendGetProductsRequest();
                ViewData["DeleteMessage"] = message;
                return View(products);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ProductViewModel? product = await _manager.SendGetProductReuqest(id);

                return View("ProductInfo", product);
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            try
            {
                return View("ProductEntryForm");
            }
            catch (Exception ex)
            {
                return this.Problem(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] ProductViewModel product)
        {
            try
            {
                _logger.LogInformation(product.ToString());
                if (ModelState.IsValid)
                {
                    var p = await _manager.SendAddProductRequest(product);
                    if (p)
                    {
                        this.ViewData["message"] = "Product Added Successfully";
                    }
                    else
                    {
                        this.ViewData["message"] = "Product Could not be added";
                    }
                }
            }
            catch (Exception ex)
            {
                this.ViewData["message"] = ex.ToString();
            }
            return View("ProductEntryForm");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var p = await _manager.SendGetProductReuqest(id);
                if (p != null)
                {
                    //this.ViewBag.ErrorMessage = "";
                    return View("ProductUpdateForm", p);
                }
                else
                {
                    this.ViewBag.ErrorMessage = "Could nt get the product data";
                    return View("ProductUpdateForm");
                }
            }
            catch (Exception ex)
            {
                this.ViewBag.ErrorMessage = ex.ToString();
                return View("ProductUpdateForm");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, [FromForm] ProductViewModel product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var p = await _manager.SendUpdateProductRequest(product);
                    if (p)
                        ViewData["UpdateMessage"] = "Updated Sucessfully";
                    else
                        ViewData["UpdateMessage"] = "could nt update";
                }
            }
            catch (Exception ex)
            {
                ViewData["UpdateMessage"] = ex.ToString();
            }
            return View("ProductUpdateForm", product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation(id.ToString());
                var result = await _manager.SendDeleteProductRequest(id);
                if (result)
                {
                    return RedirectToAction("GetAll", new { id = "deleted successfully" });
                }
                else
                    return RedirectToAction("GetAll", new { id = "could not delete" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("GetAll", new { id = ex.ToString() });
            }

        }
    }
}
