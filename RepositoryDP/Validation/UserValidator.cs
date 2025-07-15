using FluentValidation;
using RepositoryDP.DTO.UserDTO;

namespace RepositoryDP.Validation
{
    public class UserValidator :AbstractValidator<AddUserAddressDTO>
    {
        public UserValidator()
        {
            RuleFor(a  => a.UserName).NotEmpty().WithMessage("UserName Must be NotEmpty")
                .MinimumLength(3).WithMessage("UserName More Than 3 Char");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password Must be NotEmpty")
                .MinimumLength(6).WithMessage("Password More Than 6 Char");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email Must be NotEmpty")
                .MinimumLength(3).WithMessage("Email More Than 3 Char");
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name Must be NotEmpty")
                .MinimumLength(3).WithMessage("Name More Than 3 Char");
            RuleForEach(a=>a.addresses).SetValidator(new AddressValidator ());
        }
    }
}
