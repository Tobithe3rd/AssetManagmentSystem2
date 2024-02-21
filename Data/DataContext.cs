using AssetManagmentSystem2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AssetManagmentSystem2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Category> Category { get; set; }
        //public DbSet<Image> Images { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<AssetCategory> AssetCategories { get; set; }
        public DbSet<AssetUser> AssetUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AssetCategory>()
            //     .HasKey(ac => new { ac.AssetId, ac.CategoryId });
            //modelBuilder.Entity<AssetCategory>()
            //    .HasOne(a => a.Asset)
            //    .WithMany(ac => ac.AssetCategories)
            //    .HasForeignKey(a => a.AssetId);
            //modelBuilder.Entity<AssetCategory>()
            //   .HasOne(c => c.Category)
            //   .WithMany(ac => ac.AssetCategories)
            //   .HasForeignKey(c => c.CategoryId);

            //modelBuilder.Entity<AssetUser>()
            //    .HasKey(au => new { au.AssetId, au.UserId });
            //modelBuilder.Entity<AssetUser>()
            //    .HasOne(a => a.Asset)
            //    .WithMany(au => au.AssetUsers)
            //    .HasForeignKey(a => a.AssetId);
            //modelBuilder.Entity<AssetUser>()
            //   .HasOne(u => u.User)
            //   .WithMany(au => au.AssetUsers)
            //   .HasForeignKey(u=> u.UserId);

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Data Source=Data Source=DESKTOP-N7BGF8U\\SQLEXPRESS;Initial Catalog=AssetManagmentSystem2;Integrated Security=True;Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}


    }
}
