using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Service.ProductService
{
    public interface IProductService
    {
        public Task AddProduct(AddProductDTO addProductDTO);
        public void UpdateProduct(int id ,UpdateProductDTO updateProductDTO);
        public void DeleteProduct(int id);
        public IList<Product> GetProducts();
        public Product GetProductById(int id);

    }
}
