using AutoMapper;
using RepositoryDP.DTO.ProductDTO;
using RepositoryDP.Model;

namespace RepositoryDP.AutoMapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,AddProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
