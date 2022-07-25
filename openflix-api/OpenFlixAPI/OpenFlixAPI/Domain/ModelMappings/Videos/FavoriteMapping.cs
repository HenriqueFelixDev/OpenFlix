using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.ModelMappings.Videos
{
    public class FavoriteMapping : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("favorites");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.ProfileId);
            builder.HasOne(p => p.Profile)
                .WithOne(profile => profile.Favorite)
                .HasForeignKey<Favorite>(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Series)
                .WithMany(serie => serie.Favorites)
                .UsingEntity(j => j.ToTable("Favorite_Serie"));
        }
    }
}
