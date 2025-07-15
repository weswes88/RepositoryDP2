using AutoMapper;
using RepositoryDP.DTO.AddressDTO;
using RepositoryDP.Model;

namespace RepositoryDP.AutoMapper
{
    public class AddressProfile :Profile
    {
        public AddressProfile()
        {
            CreateMap<Address,CreateAddressDTO>().ReverseMap();
            CreateMap<Address,UpdateAddressDTO>().ReverseMap();
            CreateMap<Address,GetAddressDTO>().ReverseMap();
        }
    }
}
