using Microsoft.EntityFrameworkCore;
using ST10451547_CLOUD_COMPUTING_PART2.Data.Entities;

namespace ST10451547_CLOUD_COMPUTING_PART2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        internal DbSet<User> User { get; set; }
        internal DbSet<Product> Product { get; set; }
        internal DbSet<Role> Role { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
            });
        }
    }
}
