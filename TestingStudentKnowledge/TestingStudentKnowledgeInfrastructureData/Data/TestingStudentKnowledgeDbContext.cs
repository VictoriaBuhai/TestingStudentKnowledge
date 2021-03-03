using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestingStudentKnowledgeDomain.Models;

namespace TestingStudentKnowledgeInfrastructureData.Data
{
    public class TestingStudentKnowledgeDbContext
    {
        public TestingStudentKnowledgeDbContext()
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Should in future implement optionsBuilder.UseSqlServer ... something like this
        //}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<User> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Admin>().ToTable("Admins");
        //    modelBuilder.Entity<Guest>().ToTable("Guests");
        //    modelBuilder.Entity<User>().ToTable("Users");
        //}
    }
}
