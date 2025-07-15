using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Repository.ProductRepo
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task AddProduct(Product product);
        public void UpdateProduct(int id , Product product);
        public string DeleteProduct(int id);
        public IList<Product> GetProducts();
        public Product GetProductById(int id);
    }
}
