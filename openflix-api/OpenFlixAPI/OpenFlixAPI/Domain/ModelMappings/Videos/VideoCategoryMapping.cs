using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.ModelMappings.Videos
{
    public class VideoCategoryMapping : IEntityTypeConfiguration<VideoCategory>
    {
        public void Configure(EntityTypeBuilder<VideoCategory> builder)
        {
            builder.ToTable("video_categories");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
        }
    }
}
