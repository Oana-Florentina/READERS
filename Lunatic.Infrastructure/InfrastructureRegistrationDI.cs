
using Lunatic.Application.Contracts;
using Lunatic.Application.Persistence;
using Lunatic.Infrastructure.Repositories;
using Lunatic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Lunatic.Infrastructure {
	public static class InfrastructureRegistrationDI {
		public static IServiceCollection AddInfrastrutureToDI(
			this IServiceCollection services,
			IConfiguration configuration) {
			services.AddDbContext<LunaticContext>(
				options =>
					options.UseNpgsql(
						configuration.GetConnectionString("LunaticConnection"),
						builder => builder.MigrationsAssembly(typeof(LunaticContext).Assembly.FullName)));

			services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookClubRepository, BookClubRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICoverRepository, CoverRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IFriendRecommandationRepository, FriendRecommandationRepository>();
            services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
            services.AddScoped<IEmailService, EmailService>();
			return services;
		}
	}
}
