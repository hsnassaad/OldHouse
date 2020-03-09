using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OldHouse.Models;
using System;

namespace OldHouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
