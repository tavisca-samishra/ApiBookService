using FluentValidation;
using WebApplication1.Models;


namespace WebApplication1
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id can't be negative or 0.");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price can't be negative or 0.");

            RuleFor(x => x.Title)
               .NotEmpty()
               .WithMessage("Title cannot be blank.")
               .Matches(@"^[a-zA-Z\s]+$")
               .WithMessage("Title Should Only Contain Letters");
            RuleFor(x => x.Genre)
               .NotEmpty()
               .WithMessage("Category cannot be blank.")
               .Matches(@"^[a-zA-Z\s]+$")
               .WithMessage("Category Should Only Contain Letters");
            RuleFor(x => x.Author)
               .NotEmpty()
               .WithMessage("Author cannot be blank.")
               .Matches(@"^[a-zA-Z\s]+$")
               .WithMessage("Author Should Only Contain Letters");
        }
    }
}
