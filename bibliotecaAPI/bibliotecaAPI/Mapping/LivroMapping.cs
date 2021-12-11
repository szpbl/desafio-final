using bibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bibliotecaAPI.Mapping
{
    public class LivroMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);
            builder.Property(x => x.Title).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(x => x.ISBN).IsRequired();
            builder.Property(x => x.PublishingYear).HasColumnType("BIGINT").IsRequired();
            builder.Property(x => x.CeratedIn).HasColumnType("DATETIME").IsRequired();
            builder.ToTable("books");
        }
    }
}
