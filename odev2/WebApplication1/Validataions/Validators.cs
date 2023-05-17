using Odev2Schema.Staff;
using FluentValidation;

namespace Odev2Service.Validataions;

public class StaffRequestValidator : AbstractValidator<StaffRequest>
{
    public StaffRequestValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Email).NotEmpty().MaximumLength(30);
        RuleFor(x => x.Phone).NotEmpty().MaximumLength(30);
        RuleFor(x => x.DateOfBirth).NotEmpty();
        RuleFor(x => x.AddressLine1).NotEmpty().MaximumLength(100);
        RuleFor(x => x.City).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Country).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Province).NotEmpty().MaximumLength(20);
    }
}

