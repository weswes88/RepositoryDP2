using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RepositoryDP.Model
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }

        //''''''''''''' User 1===>M Addresses
        //[JsonIgnore]
        [JsonInclude]
        public virtual ICollection<Address> addresses { get; set; }

    }
}
