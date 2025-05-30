using Microsoft.Extensions.Logging;

namespace ProductManagementSystem.Repository
{
    public class ProductRepository(PmsDbContext context) : IProductRepository
    {
        private readonly PmsDbContext _context = context;

        public int Delete(int id)
        {
            try
            {
                var found = Exists(id);
                _context.Products.Remove(found);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product Fetch(int id)
        {
            try
            {
                var found = Exists(id);
                return found;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> FetchAll()
        {
            try
            {
                return [.. _context.Products];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> FilterProductsByName(string name = "")
        {
            try
            {
                return [.. _context.Products.Where(p => p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Product entity)
        {
            try
            {
                _context.Products.Add(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(int id, Product entity)
        {
            try
            {
                var found = Exists(id);
                _context.Products.Update(entity);
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Product Exists(int id)
        {
            var found = _context.Products.Where(p => p.Id == id);
            if (found != null && found.Any())
                return found.First();
            else
                throw new Exception($"product with id: {id} does not exist");
        }
    }
}
