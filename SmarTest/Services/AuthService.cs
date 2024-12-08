using SmarTest.DataLayer;
using SmarTest.DataLayer.Models;
using SmarTest.Services.Interfaces;

namespace SmarTest.Services
{
    public class AuthService : IAuthService
    {
        private readonly SmarTestDbContext smarTestDbContext;
        public AuthService(SmarTestDbContext smarTestDbContext)
        {
            this.smarTestDbContext = smarTestDbContext;
        }
        private readonly List<User> _users = new List<User>
        {
            new User {  FirstName = "student", LastName = "student", IsTeacher = false },
            new User {  FirstName = "teacher", LastName = "teacher", IsTeacher = true , Username="admin"},
        };

        public User LoggedInUser { get; set; } = null!;

        public Task<bool> LoginAsync(string firstName, string lastName)
        {
            if (firstName == "student" && lastName == "student")
            {
                LoggedInUser = _users[0];
                return Task.FromResult(true);
            }

            if (firstName == "teacher" && lastName == "teacher")
            {
                LoggedInUser = _users[1];
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public async Task LogoutAsync()
        {
            LoggedInUser = null;
            await Task.CompletedTask;
        }
    }
}
