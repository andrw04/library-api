using FluentValidation;
using Library.Business.Models.User;

namespace Library.Business.Validators.User;

public class LoginUserValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserValidator()
    {
        RuleFor(u => u.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(u => u.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress();
    }
}