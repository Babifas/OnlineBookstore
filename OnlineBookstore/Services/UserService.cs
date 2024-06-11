using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services
{
    public class UserService
    {
        private readonly MyDbContext _dbContext;
        public UserService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var users =await _dbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving users", ex);
            }
        }
        public async Task<User> GetUserById(int userId)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
                if (user == null)
                {
                    throw new Exception("User not found");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the user", ex);
            }
        }
    }
}
