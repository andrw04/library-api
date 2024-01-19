using FluentValidation;
using Library.Business.Models.Author;

namespace Library.Business.Validators.Author;

public class RequestAuthorValidator : AbstractValidator<RequestAuthorDto>
{
    public RequestAuthorValidator()
    {
        RuleFor(a => a.FirstName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(a => a.LastName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3);
    }
}
