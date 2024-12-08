using SmarTest.Services.Interfaces;
using SmarTest.DataLayer.Models;
using SmarTest.DataLayer;
using MongoDB.Bson;

namespace SmarTest.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(SmarTestDbContext dbContext) : base(dbContext) { }

        public async Task<List<User>> GetAllUsers()
        {
            var result = await GetAllAsync();
            return result.ToList();
        }

        public async Task AddUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            await AddAsync(user);
        }

        public async Task EditUserAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var existingUser = await GetByIdAsync(user._id);
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Username = user.Username;
                existingUser.IsTeacher = user.IsTeacher;
                existingUser.StudentClass = user.StudentClass;

                await UpdateAsync(existingUser);
            }
        }

        public async Task DeleteUserAsync(ObjectId id)
        {
            await DeleteAsync(id);
        }
    }
}
