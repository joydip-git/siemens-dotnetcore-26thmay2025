using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.DataAccessLayer
{
    public class ProductDao : IPmsDao<ProductDto, string>
    {
        public ProductDto? Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductDto? GetById(string id)
        {
            throw new NotImplementedException();
        }

        public ProductDto? Insert(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public ProductDto? Update(string id, ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
