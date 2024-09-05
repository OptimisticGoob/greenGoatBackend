using Microsoft.EntityFrameworkCore;
using GreenGoat.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GreenGoat.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users {get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
        .HasMany(u => u.Followers)
        .WithMany(u => u.Following)
         .UsingEntity<Dictionary<string, object>>(
            "UserFollowers",
            j => j
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("FollowerId")
                .OnDelete(DeleteBehavior.Restrict),
            j => j
                .HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict),
            j =>
            {
                j.HasKey("UserId", "FollowerId");
                j.ToTable("UserFollowers");
            });

    }
}