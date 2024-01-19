using FluentValidation;
using Library.Business.Models.Genre;

namespace Library.Business.Validators.Genre;

public class RequestGenreValidator : AbstractValidator<RequestGenreDto>
{
    public RequestGenreValidator()
    {
        RuleFor(g => g.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(g => g.Description)
            .NotNull()
            .NotEmpty();
    }
}
