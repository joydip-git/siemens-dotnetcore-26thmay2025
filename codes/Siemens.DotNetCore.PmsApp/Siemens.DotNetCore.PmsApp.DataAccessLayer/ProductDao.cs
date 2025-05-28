using Siemens.DotNetCore.PmsApp.Entities;

namespace Siemens.DotNetCore.PmsApp.DataAccessLayer
{
    public class ProductDao : IPmsDao<Product, string>
    {
        public Product? Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product? GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Product? Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product? Update(string id, Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
