using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryDP.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }

        //self Relation
        public virtual ICollection<Category> SubCategory { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
