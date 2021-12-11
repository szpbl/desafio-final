using biblioteca.Data.Repositories.Interfaces;
using bibliotecaAPI.Context;
using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace biblioteca.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Fields

        private readonly LibraryDbContext _context;

        #endregion

        #region Constructor

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<bool> AddAsync(User user)
        {
            _context.Users.Add(user);

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<User> ReturnByCredentials(string email, string password)
        {

            return await _context.Users.Include(x => x.Role).SingleOrDefaultAsync(user => user.Email == email && user.Password == password);

        }

  

        #endregion
    }
}
