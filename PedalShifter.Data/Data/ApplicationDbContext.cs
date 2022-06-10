using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PedalShifter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedalShifter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<HostOpenHour> HostOpenHours { get; set; }
    }
}
