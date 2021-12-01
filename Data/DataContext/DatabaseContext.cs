using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataContext
{
    public class DatabaseContext:DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            } 
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();
           
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //DBSETS GO HERE
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    
            modelBuilder.Entity<Degree>()
                .HasKey(d => new { d.IdDegree });

            modelBuilder.Entity<Levell>().HasData(
                new Levell { Id = 1, Levelname = "PRIMARY", Turn = "LATE" },
                new Levell { Id = 2, Levelname = "HIGH SCHOOL", Turn = "MORNING" }
            );


            modelBuilder.Entity<Degree>().HasData(
                   new Degree { IdDegree = 1, DegreeName = "FIRST", DegreeDateCreated = new DateTime(2021, 08, 30), NumStudent = 25, LevellId = 1 },
                   new Degree { IdDegree = 2, DegreeName = "SECOND", DegreeDateCreated = new DateTime(2021, 08, 30), NumStudent = 28, LevellId = 2 }
               );
        }
        public DbSet<Levell> levels { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Paremet> Paramets { get; set; }
        public DbSet<ParametersSystem> ParametersSystems { set; get; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Apoderado> Apoderados { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<GradosCurso> GradosCurso { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Retirado> Retirados { get; set; }
        public DbSet<AssignTLDCS> AssignTLDCS { get; set; }
        public DbSet<Calendario> calendarios { get; set; }


    }  
}
