using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.APIServer.Models;
using ProductManagementSystem.Repository;

namespace ProductManagementSystem.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AnonymousAccess")]
    public class ProductController(IProductRepository repository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Route("all")]
        [Authorize]
        public ActionResult<List<ProductReadDto>> GetAllProducts()
        {
            try
            {
                var result = repository.FetchAll();

                if (result != null && result.Count > 0)
                {
                    var response = mapper.Map<List<ProductReadDto>>(result);
                    return Ok(response);
                }
                else
                    return NotFound("could not find any record");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpGet]
        [Route("view/{id}")]
        [Authorize]
        public ActionResult<ProductReadDto> GetProduct(int id)
        {
            try
            {
                var result = repository.Fetch(id);
                var response = mapper.Map<ProductReadDto>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public ActionResult<ProductReadDto> AddProduct(ProductWriteDto product)
        {
            try
            {
                var productToAdd = mapper.Map<Product>(product);
                var result = repository.Insert(productToAdd);
                if (result > 0)
                {
                    var records = repository.FetchAll();
                    var found = records.Last();
                    var response = mapper.Map<ProductReadDto>(found);
                    return CreatedAtAction("AddProduct", response);

                }
                else
                    return this.Problem("could not add record");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        [Authorize]
        public ActionResult<ProductReadDto> UpdateProduct(int id, ProductWriteDto product)
        {
            try
            {
                var productToUpdate = mapper.Map<Product>(product);
                var result = repository.Update(id, productToUpdate);
                if (result > 0)
                {
                    var response = mapper.Map<ProductReadDto>(product);
                    response.Id = id;
                    return Ok(response);
                }
                else
                    return this.Problem("could not update record");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Authorize]
        public ActionResult<string> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var result = repository.Delete(id);
                if (result > 0)
                {
                    return Ok($"{result} record deleted...");
                }
                else
                    return this.Problem("could not delete record");
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }
    }
}
