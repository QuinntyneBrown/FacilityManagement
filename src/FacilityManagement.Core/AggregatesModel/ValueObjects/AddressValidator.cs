using FluentValidation;

namespace FacilityManagement.Core
{
    public class AddressValidator: AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street).NotEmpty().NotNull();
            RuleFor(address => address.City).NotEmpty().NotNull();
            RuleFor(address => address.Province).NotEmpty().NotNull();
            RuleFor(address => address.PostalCode).NotEmpty().NotNull();
        }
    }
}
