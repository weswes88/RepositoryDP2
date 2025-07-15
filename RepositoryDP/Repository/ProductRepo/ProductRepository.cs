using Microsoft.EntityFrameworkCore;
using RepositoryDP.Data;
using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;
using System.Linq;

namespace RepositoryDP.Repository.ProductRepo
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {

        public ProductRepository(EFContext _context) : base(_context)
        {
            
        }
        public async Task AddProduct(Product product)
        {
           

            var cat = _context.Categories.Where(a => a.CatName.ToLower() == product.category.CatName.ToLower()).FirstOrDefault();
            if (cat != null)
            {
                 product.category = cat;
            }
            await CreateAsync(product);

            //_context.Products.Add(product);
            //_context.SaveChanges();
           

        }
        public void UpdateProduct(int id, Product product)
        {
            var res = _context.Products.Find(id);
            res.Pro_Name = product.Pro_Name;
            //res.Pro_Category = product.Pro_Category;
            res.Pro_Description = product.Pro_Description;
            res.Price = product.Price;
            _context.Products.Update(res);
            _context.SaveChanges();
        }
        public string DeleteProduct(int id)
        {
            var res = _context.Products.Find(id);
            if (res != null)
            {
                _context.Remove(res);
                _context.SaveChanges();
                return "Delete Record Success";
            }
            else
            {
                return "Error When Delete Record";
            }
            
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
