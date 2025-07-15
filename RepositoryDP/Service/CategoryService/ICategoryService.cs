using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Service.CategoryService
{
    public interface ICategoryService
    {
        public string CreateCategory(CreateCategoryDTO categoryDTO);
        public UpdateCategoryDTO UpdateCategory(int id, UpdateCategoryDTO updateCategoryDTO);
        public IList<GetCategoryDTO> GetCategories();

        public string DeleteCategory(int id);
    }
}
