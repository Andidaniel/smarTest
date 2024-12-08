using SmarTest.Services.Interfaces;
using SmarTest.DataLayer.Models;
using SmarTest.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace SmarTest.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(SmarTestDbContext dbContext) : base(dbContext) { }

        public async Task<List<User>> GetAllUsersWithClasses()
        {
            var usersWithClasses = new List<User>();
            try
            {
                usersWithClasses = await _dbContext.Users
                    .ToListAsync();
            }
            catch (Exception ex) { }

            return usersWithClasses;
        }
    }
}
