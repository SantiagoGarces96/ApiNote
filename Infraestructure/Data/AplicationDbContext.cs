using Core.Entities;
using Infraestructure.Data.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AcademicLevelConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<AcademicLevel> AcademicLevels { get; set; }

        public DbSet<Note> Notes { get; set; }

    }
}
