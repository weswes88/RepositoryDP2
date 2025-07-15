using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryDP.Model
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string Pro_Name { get; set; }
        public string Pro_Description { get; set; }
        [Required]
        public double Price { get; set; }


        public int? CatID { get; set; }
        [ForeignKey("CatID")]
        public virtual Category category { get; set; }

    }
}
