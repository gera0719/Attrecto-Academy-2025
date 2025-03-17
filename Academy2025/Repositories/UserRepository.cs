using Academy2025.Data;
using Microsoft.EntityFrameworkCore;

namespace Academy2025.Repositories
{
    public class UserRepository : IUserRepository
    {
        //public static List<User>? Users = new List<User>();
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return _context.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task CreateAsync(User data) /*mivel van muvelet add utan, be kell varnunk a kovi muveletnel -> await*/
        {
            await _context.Users.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public  Task<int> UpdateAsync() 
            => _context.SaveChangesAsync();

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);

                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
        public Task<List<User>> GetAllOverEighteenAsync()
        {
            //return (from user in _context.Users where user.age >= 18 select user).ToListAsync();
            return _context.Users.Where(user => user.Age >= 18).ToListAsync();
        }

        public Task<User?> GetByEmailAsync(string email)=>
            _context.Users.FirstOrDefaultAsync(user => user.Email == email);    
    }
}
