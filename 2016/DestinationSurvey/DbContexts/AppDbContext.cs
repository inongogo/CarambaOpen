using System;
using CarambaOpen.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace CarambaOpen.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            Database.EnsureCreated();

            // Lazy loading is not available in RC1
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = true;
        }

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Startup.Configuration != null)
            {
                var connString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];

                if (!string.IsNullOrEmpty(connString))
                {
                    optionsBuilder.UseSqlServer(connString);
                }
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Answer>()
                .HasOne(a => a.Poll)
                .WithMany(p => p.Answers);
            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers);
            builder.Entity<Poll>()
                .HasOne(p => p.User)
                .WithMany(u => u.Polls);
        }

        public DbSet<Poll> Polls { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Destination> Destinations { get; set; }
    }
}