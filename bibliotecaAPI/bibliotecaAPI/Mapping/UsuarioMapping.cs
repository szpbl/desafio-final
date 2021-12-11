using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bibliotecaAPI.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("VARCHAR(255)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(x => x.CreatedIn).HasColumnType("DATETIME").IsRequired();
            builder.ToTable("users");

        }
    }
}
