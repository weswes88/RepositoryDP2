namespace RepositoryDP.DTO.AddressDTO
{
    public class UpdateAddressDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public int FlatNum { get; set; }
        public int? UserId { get; set; }
    }
}
