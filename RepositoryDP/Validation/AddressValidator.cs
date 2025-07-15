using FluentValidation;
using RepositoryDP.DTO.AddressDTO;

namespace RepositoryDP.Validation
{
    public class AddressValidator :AbstractValidator <CreateAddressDTO>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Country).GreaterThan("1").WithMessage("Country Must be More than 1 char");
            RuleFor(a => a.City).GreaterThan("1").WithMessage("City Must be More than 1 char");
            RuleFor(a => a.Phone).Length(11).WithMessage("Phone Must be More than 11 num");
            //RuleFore(a => a.PostalCode).GreaterThan("2").WithMessage("PostalCode Must be More than 2 char");
            RuleFor(a => a.FlatNum).GreaterThan(0).WithMessage("FlatNum Must be More than 0");
        }
    }
}
