using bibliotecaAPI.Context;
using bibliotecaAPI.Dados.Repositorios.Interfaces;
using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bibliotecaAPI.Dados.Repositorios
{
    public class AuthorsRepository : IAuthorsRepository
    {

        #region Fields

        private readonly LibraryDbContext _context;

        #endregion

        #region Constructor

        public AuthorsRepository(LibraryDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Author>> ListAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<bool> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);

            return await _context.SaveChangesAsync() == 1;
        }

        #endregion

    }
}
