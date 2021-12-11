using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bibliotecaAPI.Mapping
{
    public class AutorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(x => x.LastName).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(x => x.CreatedIn).HasColumnType("DATETIME").IsRequired();
            builder.ToTable("authors");
        }
    }
}
