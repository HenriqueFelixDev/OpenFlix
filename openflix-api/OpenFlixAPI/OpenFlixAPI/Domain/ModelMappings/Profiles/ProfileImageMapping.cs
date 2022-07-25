using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.ModelMappings.Profiles
{
    public class ProfileImageMapping : IEntityTypeConfiguration<ProfileImage>
    {
        public void Configure(EntityTypeBuilder<ProfileImage> builder)
        {
            builder.ToTable("profile_images");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ImageName).HasMaxLength(255).IsRequired();
        }
    }
}
