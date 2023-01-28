using AdaptITAcademyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptItAcademy.DataAccess.Models
{
    public class AdaptITAcademyContext : DbContext
    {
        public AdaptITAcademyContext()
        {
        }

        public AdaptITAcademyContext(DbContextOptions<AdaptITAcademyContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PhysicalAddress> PhysicalAddresses { get; set; }
        public DbSet<PostalAddress> PostalAddresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<UserTraining> UserTrainings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // can move to service registration & appsettings config access it.
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdaptItAcademyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>().Property(prop => prop.TrainingCost).HasColumnType("decimal(18,2)");
        }
    }
}

