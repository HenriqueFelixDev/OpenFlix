using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenFlixAPI.Domain.ModelMappings.Users
{
    public class UserMapping : IEntityTypeConfiguration<Models.Users.User>
    {
        public void Configure(EntityTypeBuilder<Models.Users.User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Username).HasMaxLength(32).IsRequired();
            builder.HasIndex(p => p.Username).IsUnique();
            builder.Property(p => p.Email).HasMaxLength(128).IsRequired();
            builder.HasIndex(p => p.Email).IsUnique();
            builder.Property(p => p.Password).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CreatedAt).ValueGeneratedOnAdd().HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.UpdatedAt).ValueGeneratedOnUpdate();
        }
    }
}
