using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SweeftAccelerationConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftAccelerationConsole
{
    public class SweeftDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer($"Data Source=(localdb)\\ProjectModels;Initial Catalog=SweeftDb;Integrated Security=True;");
    }
}
