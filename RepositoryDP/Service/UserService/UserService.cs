using AutoMapper;
using RepositoryDP.DTO.UserDTO;
using RepositoryDP.Model;
using RepositoryDP.Repository.UserRepo;

namespace RepositoryDP.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddUserAddressDTO> AddUser(AddUserAddressDTO addUserAddressDTO)
        {
            var map = _mapper.Map<User>(addUserAddressDTO);
            var res = await _repository.CreateAsync(map);
            var response = _mapper.Map<AddUserAddressDTO>(res);
            return response;
        }

        public async Task DeleteUser(int id)
        {
            await _repository.DeleteAsync(id);
        }
        public async Task<User> UpdateUser(UpdateUserAddressDTO updateUserAddressDTO)
        {
            var map =_mapper.Map<User>(updateUserAddressDTO);
            var repo = await _repository.UpdateAsync(map);
            return repo;
        }
        public async Task<User> GetById(int id)
        {
            var repo= await _repository.GetByIdAsync(id);
            return repo;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var repo =await _repository.GetAllAsync();
            return repo;
        }

       
    }
}
