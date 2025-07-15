using RepositoryDP.DTO.CategoryDTO;
using System.ComponentModel.DataAnnotations;

namespace RepositoryDP.DTO.ProductDTO
{
    public class AddProductDTO
    {
        //public int id { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        public double Price { get; set; }
        public CreateCategoryDTO Category {  get; set; }
    }
}
