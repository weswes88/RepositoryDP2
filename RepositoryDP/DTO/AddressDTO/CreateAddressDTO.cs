using RepositoryDP.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepositoryDP.DTO.AddressDTO
{
    public class CreateAddressDTO
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int FlatNum { get; set; }
 
        
    }
}
