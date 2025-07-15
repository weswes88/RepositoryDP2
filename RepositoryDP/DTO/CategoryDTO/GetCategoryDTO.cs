using RepositoryDP.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryDP.DTO.CategoryDTO
{
    public class GetCategoryDTO
    {
        public int Id { get; set; }
        public string CatName { get; set; }

    }
}
