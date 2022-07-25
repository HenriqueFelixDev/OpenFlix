using Microsoft.EntityFrameworkCore;
using OpenFlixAPI.Domain.ModelMappings.Profiles;
using OpenFlixAPI.Domain.ModelMappings.Users;
using OpenFlixAPI.Domain.ModelMappings.Videos;
using OpenFlixAPI.Domain.Models.Profiles;
using OpenFlixAPI.Domain.Models.Users;
using OpenFlixAPI.Domain.Models.Videos;

namespace OpenFlixAPI.Domain.Repositories
{
    public partial class Context : DbContext
    {
        private IConfiguration _configuration;
        public Context() { }
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileImage> ProfileImages { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var connectionString = "Server=localhost;Database=openflix_db;Uid=root;Pwd=admin;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ProfileMapping());
            modelBuilder.ApplyConfiguration(new ProfileImageMapping());
            modelBuilder.ApplyConfiguration(new SerieMapping());
            modelBuilder.ApplyConfiguration(new VideoMapping());
            modelBuilder.ApplyConfiguration(new VideoCategoryMapping());
            modelBuilder.ApplyConfiguration(new FavoriteMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
