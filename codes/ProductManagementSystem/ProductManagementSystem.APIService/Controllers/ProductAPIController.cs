using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Entities;
using ProductManagementSystem.Repository;

namespace ProductManagementSystem.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController(IEpsilonDbRepository<Product, int> repository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        [Authorize]
        public ActionResult<IEnumerable<ProductQueryDto>> GetProducts()
        {
            try
            {
                var records = repository.FetchAll();
                if (records != null && records.Count > 0)
                {
                    var response = mapper.Map<List<ProductQueryDto>>(records);
                    return Ok(response);
                }
                else
                {
                    return NotFound("no records found...");
                }
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        [Authorize]
        public ActionResult<ProductQueryDto> GetProduct([FromRoute] int id)
        {
            try
            {
                var product = repository.Fetch(id);
                var response = mapper.Map<ProductQueryDto>(product);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public ActionResult<string> AddProduct([FromBody] ProductComandDto product)
        {
            try
            {
                var productToAdd = mapper.Map<Product>(product);
                var status = repository.Insert(productToAdd);
                return status ? CreatedAtAction(nameof(AddProduct), "product added successfully") : BadRequest("could not add the product");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("update/{id}")]
        public ActionResult<string> UpdateProduct([FromRoute] int id, [FromBody] ProductComandDto product)
        {
            try
            {
                var productToUpdate = mapper.Map<Product>(product);
                var status = repository.Update(id, productToUpdate);
                return status ? Ok("product updated successfully") : BadRequest("could not update the product");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("delete/{id}")]
        public ActionResult<string> RemoveProduct([FromRoute] int id)
        {
            try
            {
                var status = repository.Delete(id);
                return status ? Ok("product deleted successfully") : BadRequest("could not delete the product");
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
