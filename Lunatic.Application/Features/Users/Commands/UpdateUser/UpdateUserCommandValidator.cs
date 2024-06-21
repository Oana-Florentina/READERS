
using FluentValidation;
using Lunatic.Application.Persistence;


namespace Lunatic.Application.Features.Users.Commands.UpdateUser {
	internal class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand> {
		private readonly IUserRepository userRepository;
		private readonly IBookClubRepository bookClubRepository;

		public UpdateUserCommandValidator(IUserRepository userRepository, IBookClubRepository bookClubRepository) {
			this.userRepository = userRepository;
			this.bookClubRepository = bookClubRepository;

			RuleFor(request => request.UserId)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.")
				.MustAsync(async (userId, cancellationToken) => await this.userRepository.ExistsByIdAsync(userId))
				.WithMessage("{PropertyName} must exist.");

			RuleFor(request => request.FirstName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.")
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(request => request.LastName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull().WithMessage("{PropertyName} is required.")
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

			RuleFor(request => request.Email)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull().WithMessage("{PropertyName} is required.")
			.MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
			.EmailAddress().WithMessage("{PropertyName} is not a valid email address.");
			

			

          

            ClassLevelCascadeMode = CascadeMode.Stop;
		}
	}
}
