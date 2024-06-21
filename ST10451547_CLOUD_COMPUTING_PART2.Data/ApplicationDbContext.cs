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
        internal DbSet<LineItem> LineItem { get; set; }
        internal DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {

                entity.HasKey(e => e.UsersId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID);
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
            });
        }
    }
}
