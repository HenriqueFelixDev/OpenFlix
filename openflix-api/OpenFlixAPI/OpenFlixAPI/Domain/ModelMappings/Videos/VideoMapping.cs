using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.ModelMappings.Videos
{
    public class VideoMapping : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("videos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Banner).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Duration).IsRequired();
            builder.Property(p => p.Url).HasMaxLength(255).IsRequired();
            builder.Property(p => p.SerieId).IsRequired();
            builder.HasOne(p => p.Serie)
                .WithMany(s => s.Videos)
                .HasForeignKey(p => p.SerieId);
        }
    }
}
