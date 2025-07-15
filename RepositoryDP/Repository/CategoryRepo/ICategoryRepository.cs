using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Repository.CategoryRepo
{
    public interface ICategoryRepository
    {
        public string CreateCategory(Category category);
        public Category UpdateCategory(int id , UpdateCategoryDTO category);
        public string DeleteCategory(int id);
        public Category GetCategoryById(int id);
        public IList<Category> GetCategory();
    }
}
