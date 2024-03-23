using API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }


        public DbSet<User> Users { get; set; }
        public DbSet<ListItem> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Lists)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserID);

            modelBuilder.Entity<ListItem>()
                .HasKey(l => l.ID);

            modelBuilder.Entity<ListItem>()
                .HasMany(l => l.Cards)
                .WithOne(c => c.List)
                .HasForeignKey(c => c.ListID);

            modelBuilder.Entity<Card>()
                .HasKey(c => c.ID);

            modelBuilder.Entity<Card>()
                .HasMany(c => c.Logs)
                .WithOne(l => l.Card)
                .HasForeignKey(l => l.CardID);

            modelBuilder.Entity<Log>()
                .HasKey(l => l.ID);
        }
    }
}
