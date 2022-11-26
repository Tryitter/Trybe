using Tryitter.Models;
using Microsoft.EntityFrameworkCore;

namespace Tryitter.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User>? Users { get; set; }
        public DbSet<Post>? Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Post>().HasKey(p => p.PostId);


            modelBuilder.Entity<Post>()
                .HasOne<User>(u => u.User)
                    .WithMany(p => p.Posts)
                        .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                    .IsUnique();
        }
    }
}
