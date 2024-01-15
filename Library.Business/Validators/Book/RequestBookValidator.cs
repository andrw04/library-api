using FluentValidation;
using Library.Business.Models.Book;

namespace Library.Business.Validators.Book
{
    public class RequestBookValidator : AbstractValidator<RequestBookDto>
    {
        private static string _isbnPattern = "^(?:ISBN(?:-1[03])?:? )?(?=[-0-9 ]{17}$|[-0-9X ]{13}$|[0-9X]{10}$)(?:97[89][- ]?)?[0-9]{1,5}[- ]?(?:[0-9]+[- ]?){2}[0-9X]$";
        public RequestBookValidator()
        {
            RuleFor(book => book.Isbn)
                .NotNull()
                .NotEmpty()
                .Matches(_isbnPattern);

            RuleFor(book => book.Title)
                .NotNull()
                .NotEmpty();

            RuleFor(book => book.Description)
                .NotNull()
                .NotEmpty();

            RuleFor(book => book.AuthorId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(book => book.GenreId)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
