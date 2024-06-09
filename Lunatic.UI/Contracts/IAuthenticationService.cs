using Lunatic.UI.ViewModels;

namespace Lunatic.UI.Contracts
{
    public interface IAuthenticationService
    {
        Task Login(LoginViewModel loginRequest);
        Task Register(RegisterViewModel registerRequest);
        Task Logout();
    }
}
