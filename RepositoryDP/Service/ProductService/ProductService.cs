using AutoMapper;
using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;
using RepositoryDP.Repository.ProductRepo;

namespace RepositoryDP.Service.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository Repository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository _Repository, IMapper _mapper)
        {
                Repository = _Repository;
                mapper = _mapper;
        }
        public async Task AddProduct(AddProductDTO addProductDTO)
        {

            //Product product = new Product();
            //product.Pro_Name = addProductDTO.Pro_Name;
            ////product.Pro_Category = addProductDTO.Pro_Category;
            //product.Pro_Description = addProductDTO.Pro_Description;
            //product.Price = addProductDTO.Price;
            var map = mapper.Map<Product>(addProductDTO);
            await Repository.AddProduct(map);
        }

        public void UpdateProduct(int id ,UpdateProductDTO updateProductDTO)
        {
            Product product = new Product();
            product.Pro_Name = updateProductDTO.Pro_Name;
            //product.Pro_Category = updateProductDTO.Pro_Category;
            product.Pro_Description = updateProductDTO.Pro_Description;
            product.Price = updateProductDTO.Price;
            Repository.UpdateProduct(id,product);
        }

        public void DeleteProduct(int id)
        {
            Repository.DeleteProduct(id);
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
