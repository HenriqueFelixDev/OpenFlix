using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.ModelMappings.Videos
{
    public class SerieMapping : IEntityTypeConfiguration<Serie>
    {
        public void Configure(EntityTypeBuilder<Serie> builder)
        {
            builder.ToTable("series");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Banner).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Author).HasMaxLength(64).IsRequired();
            builder.Property(p => p.CategoryId);
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Series)
                .HasForeignKey(p => p.CategoryId);
        }
    }
}
