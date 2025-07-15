using RepositoryDP.Model;
using System.ComponentModel.DataAnnotations;

namespace RepositoryDP.DTO.CategoryDTO
{
    public class CreateProductCategoryDTO
    {
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public double Price { get; set; }

        public CreateCategoryDTO category { get; set; }
    }
}
