using AutoMapper;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;

namespace RepositoryDP.AutoMapper
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CreateCategoryDTO>().ReverseMap();
            CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category,GetCategoryDTO>().ReverseMap();
        }
    }
}
