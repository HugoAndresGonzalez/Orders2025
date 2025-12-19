using Microsoft.EntityFrameworkCore;
using ModeloServices.Entities;

namespace ModeloServices.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Service> Services { get; set; }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
        {
            e.HasKey("UserId");
            e.Property("UserId").ValueGeneratedOnAdd();
            e.HasData(
                new User()
                {
                    UserId = 1,
                    UserName = "Hugo González",
                    UserEmail = "ingmechgonzalez@gmail.com",
                    Password = "Admin123*"
                });
        });

        modelBuilder.Entity<Service>(e =>
        {
            e.HasKey("ServiceId");
            e.Property("ServiceId").ValueGeneratedOnAdd();
            e.HasOne(e => e.User)
             .WithMany(u => u.Services)
             .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Transaction>(e =>
        {
            e.HasKey("TransactionId");
            e.Property("TransactionId").ValueGeneratedOnAdd();
            e.Property("Date").HasColumnType("date");
            e.Property("TotalAmount").HasColumnType("decimal(10,2)");
            e.HasOne(e => e.User)
             .WithMany(u => u.Transactions)
             .HasForeignKey(e => e.UserId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasOne(e => e.Service)
             .WithMany()
             .HasForeignKey(e => e.ServiceId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}