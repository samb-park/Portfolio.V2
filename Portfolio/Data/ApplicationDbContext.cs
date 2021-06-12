using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Resume> Resume { get; set; }
        public DbSet<ResumeCategory> ResumeCategory { get; set; }


        public DbSet<Work> Work{ get; set; }
        public DbSet<WorkCategory> WorkCategory { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

    }
}
