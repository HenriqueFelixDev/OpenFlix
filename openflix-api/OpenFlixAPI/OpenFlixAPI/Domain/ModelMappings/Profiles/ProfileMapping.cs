using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Profiles;

namespace OpenFlixAPI.Domain.ModelMappings.Profiles
{
    public class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("profiles");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId);
            builder.Property(p => p.Name).HasMaxLength(32).IsRequired();
            builder.Property(p => p.ProfileImageId);
            builder.HasOne(p => p.User)
                .WithMany(u => u.Profiles)
                .HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.ProfileImage)
                .WithMany(pi => pi.Profiles)
                .HasForeignKey(p => p.ProfileImageId);
        }
    }
}
