using Microsoft.EntityFrameworkCore;
using RihalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RihalProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 
        }

        public DbSet<countries> Countries { get; set; }
        public DbSet<classes> Classes { get; set; }
        public DbSet<students> Students { get; set; }
    }
}
