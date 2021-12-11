using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaAPI.Context
{
    public class LibraryDbContext : DbContext
    {
        #region DbSets

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        #endregion

        #region Constructor

        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>()
                .HasData(
                    new Role(1, "Admin"),
                    new Role(2, "User")
                );
        }

        #endregion


    }
}
