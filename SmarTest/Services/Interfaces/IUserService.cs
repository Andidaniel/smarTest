using SmarTest.DataLayer.Models;

namespace SmarTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task AddUserAsync(User user);
        Task EditUserAsync(User user);
    }
}
