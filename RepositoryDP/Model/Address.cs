using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryDP.Model
{
    public class Address
    {  
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        [Required]
        public int FlatNum {  get; set; }
        
        //''''''''''''' User 1===>M Addresses
        public int? UserId {  get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }


    }
}
