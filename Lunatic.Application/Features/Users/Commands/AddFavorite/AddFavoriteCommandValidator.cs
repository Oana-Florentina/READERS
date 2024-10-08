﻿using FluentValidation;
using Lunatic.Application.Persistence;


namespace Lunatic.Application.Features.Users.Commands.AddFavorite
{
    internal class AddFavoriteCommandValidator : AbstractValidator<AddFavoriteCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IBookRepository bookRepository;

        public AddFavoriteCommandValidator(IUserRepository userRepository, IBookRepository bookRepository)
        {
            this.userRepository = userRepository;
            this.bookRepository = bookRepository;

            RuleFor(request => request.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
                .WithMessage("{PropertyName} must exist.");

            RuleFor(request => request.BookId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull().WithMessage("{PropertyName} is required.")
               .MustAsync(async (bookId, cancellationToken) => await this.bookRepository.ExistsByIdAsync(bookId))
               .WithMessage("{PropertyName} must exists.");

            RuleFor(request => new { request.UserId, request.BookId })
            .MustAsync(async (req, cancellationToken) => {
                var user = (await this.userRepository.FindByIdAsync(req.UserId)).Value;
                return !user.FavoriteIds.Contains(req.BookId);
            })
            .WithMessage("User must not include BookId.");

            ClassLevelCascadeMode = CascadeMode.Stop;

        }
    }
}

