using bibliotecaAPI.Models;
using System.Threading.Tasks;

namespace biblioteca.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User usuario);
        Task<User> ReturnByCredentials(string email, string senha);
    }
}
