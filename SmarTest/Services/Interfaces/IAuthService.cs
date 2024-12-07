using SmarTest.DataLayer.Models;

namespace SmarTest.Services.Interfaces
{
    public interface IAuthService
    {
        public User LoggedInUser { get; }
        Task<bool> LoginAsync(string firstName, string lastName);
        Task LogoutAsync();
    }
}
