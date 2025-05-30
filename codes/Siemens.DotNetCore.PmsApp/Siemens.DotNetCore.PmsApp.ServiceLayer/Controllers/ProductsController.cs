using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siemens.DotNetCore.PmsApp.BusinessLayer;
using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IPmsBusinessComponent<ProductDto, string> businessComponent) : ControllerBase
    {
        //private readonly IPmsBusinessComponent<ProductDto,string> _businessComponent;
        //public ProductsController(IPmsBusinessComponent<ProductDto,string> _businessComponent) 
        //{
        //    this._businessComponent = _businessComponent;
        //}

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> records = businessComponent.FetchAll();
                OkObjectResult result = this.Ok(records);
                return result;
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{productid}")]
        public ActionResult<ProductDto> GetProduct([FromRoute(Name = "productid")]string id)
        {
            try
            {
                var data = businessComponent.FetchById(id);
                return this.Ok(data);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<ProductDto> AddProduct(ProductDto productDto) 
        {
            try
            {
                var addedProduct = businessComponent.Add(productDto);
                return this.CreatedAtAction($"{nameof(AddProduct)}", addedProduct);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        //public void UpdateProduct(string id, ProductDto productDto) { }
        public ActionResult<ProductDto> DeleteProduct(string id) 
        {
            try
            {
                return this.Ok(businessComponent.Remove(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
