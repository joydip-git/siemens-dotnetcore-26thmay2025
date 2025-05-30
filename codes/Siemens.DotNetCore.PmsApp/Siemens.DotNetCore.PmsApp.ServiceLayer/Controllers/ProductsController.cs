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
        //public void AddProduct(ProductDto productDto) { }
        //public void UpdateProduct(string id, ProductDto productDto) { }
        //public void DeleteProduct(string id) { }
    }
}
