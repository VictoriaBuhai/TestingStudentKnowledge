using Microsoft.EntityFrameworkCore;
using TestingStudentKnowledgeDomain.Models.Other;
using TestingStudentKnowledgeDomain.Models.Users;

namespace TestingStudentKnowledgeInfrastructureData.Data
{
    public class TestingStudentKnowledgeDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Statistic> Statistic { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tskdb;Username=postgres;Password=sakura123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Tests");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Statistic>().ToTable("Statistics");
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}