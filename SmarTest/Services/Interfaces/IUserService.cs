using SmarTest.DataLayer.Models;

namespace SmarTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersWithClasses();
    }
}
