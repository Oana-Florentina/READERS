
using Lunatic.Application.Persistence;
using FluentValidation;
using Lunatic.Application.Features.Cover.Commands;


namespace Lunatic.Application.Features.Covers.Commands.AddCover
{
    internal class AddCoverCommandValidator : AbstractValidator<AddCoverCommand>
    {
        private readonly ICoverRepository coverRepository;
        private readonly IBookRepository bookRepository;

        public AddCoverCommandValidator(ICoverRepository coverRepository, IBookRepository bookRepository)
        {
            this.coverRepository = coverRepository;
            this.bookRepository = bookRepository;

            
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Url is required.");
           

            ClassLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
