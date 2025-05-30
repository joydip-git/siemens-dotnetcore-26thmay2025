using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.BusinessLayer
{
    public class ProductBo : IPmsBusinessComponent<ProductDto, string>
    {
        public ProductDto? Add(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> FetchAll()
        {
            throw new NotImplementedException();
        }

        public ProductDto? FetchById(string id)
        {
            throw new NotImplementedException();
        }

        public ProductDto? Modify(string id, ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public ProductDto? Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
