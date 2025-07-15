using RepositoryDP.DTO.AddressDTO;
using RepositoryDP.Model;

namespace RepositoryDP.DTO.UserDTO
{
    public class UpdateUserAddressDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        //''''''''''''' User 1===>M Addresses
        public ICollection<CreateAddressDTO> addresses { get; set; }
    }
}
