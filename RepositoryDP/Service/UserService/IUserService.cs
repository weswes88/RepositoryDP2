using Microsoft.Identity.Client;
using RepositoryDP.DTO.UserDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Service.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task <User> GetById(int id);
        Task <AddUserAddressDTO> AddUser(AddUserAddressDTO addUserAddressDTO);
        Task <User> UpdateUser(UpdateUserAddressDTO updateUserAddressDTO);
        Task DeleteUser(int id);

    }
}
