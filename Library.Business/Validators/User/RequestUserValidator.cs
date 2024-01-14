using FluentValidation;
using Library.Business.Models.User;

namespace Library.Business.Validators.User
{
    public class RequestUserValidator : AbstractValidator<RequestUserDTO>
    {
        public RequestUserValidator()
        {
            RuleFor(u => u.Username)
                .NotNull()
                .NotEmpty();

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
}
