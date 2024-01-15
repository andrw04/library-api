using FluentValidation;
using Library.Business.Models.Author;

namespace Library.Business.Validators.Author
{
    public class RequestAuthorValidator : AbstractValidator<RequestAuthorDto>
    {
        public RequestAuthorValidator()
        {
            
        }
    }
}
