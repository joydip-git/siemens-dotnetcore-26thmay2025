using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.BusinessLayer
{
    public class ProductBo : IPmsBusinessComponent<Product, string>
    {
        public Product? Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Product? FetchById(string id)
        {
            throw new NotImplementedException();
        }

        public Product? Modify(string id, Product entity)
        {
            throw new NotImplementedException();
        }

        public Product? Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
