using RepositoryDP.DTO.AddressDTO;
using RepositoryDP.Model;
using System.ComponentModel.DataAnnotations;

namespace RepositoryDP.DTO.UserDTO
{
    public class AddUserAddressDTO
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        //''''''''''''' User 1===>M Addresses
        public ICollection<CreateAddressDTO> addresses { get; set; }
    }
}
