using Lunatic.UI.Services.Responses;
using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IAuthenticationService
    {
        Task Login(LoginViewModel loginRequest);
        Task Register(RegisterViewModel registerRequest);
        Task Logout();

        Task<Response> ResetPassword(string email);
        Task<Response> ConfirmPassword(string email, string newPassword);
    }
}
