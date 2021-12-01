using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace App_Desktop.Models
{
    public partial class SystenSchoolContext : DbContext
    {
        public SystenSchoolContext()
        {
        }

        public SystenSchoolContext(DbContextOptions<SystenSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Apoderado> Apoderados { get; set; }
        public virtual DbSet<AssignTldc> AssignTldcs { get; set; }
        public virtual DbSet<Calendario> Calendarios { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<GradosCurso> GradosCursos { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Paramet> Paramets { get; set; }
        public virtual DbSet<ParametersSystem> ParametersSystems { get; set; }
        public virtual DbSet<Retirado> Retirados { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:serverschool.database.windows.net,1433;Initial Catalog=SystenSchool;Persist Security Info=False;User ID=SystemSchool;Password=ColegioPrivado123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.Property(e => e.Nombres).IsRequired();

                entity.HasOne(d => d.IdApoderadosNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdApoderados);

                entity.HasOne(d => d.IdDegreesNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdDegrees);

                
            });

            modelBuilder.Entity<Apoderado>(entity =>
            {
                entity.HasKey(e => e.IdApoderado);

                entity.Property(e => e.ApellidoM).IsRequired();

                entity.Property(e => e.ApellidoP).IsRequired();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AssignTldc>(entity =>
            {
                entity.HasKey(e => e.IdAssignTldcs)
                    .HasName("PK__AssignTL__FC908E3F5F2E8E6D");

                entity.ToTable("AssignTLDCS");

                entity.Property(e => e.IdAssignTldcs).HasColumnName("IdAssignTLDCS");

                entity.Property(e => e.TurnName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CourseIdCourseNavigation)
                    .WithMany(p => p.AssignTldcs)
                    .HasForeignKey(d => d.CourseIdCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AssignTLD__Cours__7B5B524B");

                entity.HasOne(d => d.DegreeIdDegreeNavigation)
                    .WithMany(p => p.AssignTldcs)
                    .HasForeignKey(d => d.DegreeIdDegree)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AssignTLD__Degre__7C4F7684");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.AssignTldcs)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AssignTLD__Level__7D439ABD");


                entity.HasOne(d => d.TeacherIdTeacherNavigation)
                    .WithMany(p => p.AssignTldcs)
                    .HasForeignKey(d => d.TeacherIdTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AssignTLD__Teach__7F2BE32F");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.IdCalendario);

                entity.ToTable("calendarios");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse);

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.HasKey(e => e.IdDegree);

                entity.ToTable("Degree");

                entity.Property(e => e.DegreeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Levell)
                    .WithMany(p => p.Degrees)
                    .HasForeignKey(d => d.LevellId);
            });

            modelBuilder.Entity<GradosCurso>(entity =>
            {
                entity.ToTable("GradosCurso");

                entity.HasOne(d => d.CoursesIdCourseNavigation)
                    .WithMany(p => p.GradosCursos)
                    .HasForeignKey(d => d.CoursesIdCourse);
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("levels");

                entity.Property(e => e.Levelname).IsRequired();

                entity.Property(e => e.Turn).IsRequired();
            });

            modelBuilder.Entity<Paramet>(entity =>
            {
                entity.HasKey(e => e.ParemetId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Paramets)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<ParametersSystem>(entity =>
            {
                entity.Property(e => e.Type).IsRequired();

                entity.Property(e => e.Value).IsRequired();
            });

            modelBuilder.Entity<Retirado>(entity =>
            {
                entity.Property(e => e.IdEncargado).HasColumnName("Id_Encargado");

                entity.Property(e => e.IdGrado).HasColumnName("Id_grado");

                entity.Property(e => e.IdSeccion).HasColumnName("Id_Seccion");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");

                entity.HasOne(d => d.IdEncargadoNavigation)
                    .WithMany(p => p.Retirados)
                    .HasForeignKey(d => d.IdEncargado);

                entity.HasOne(d => d.IdGradoNavigation)
                    .WithMany(p => p.Retirados)
                    .HasForeignKey(d => d.IdGrado);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.ToTable("Role");

                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.IdSection);

                entity.Property(e => e.SectionName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.IdTeacher)
                    .HasName("PK__Teacher__F515A721A9DE277A");

                entity.ToTable("Teacher");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserIdUserNavigation)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.UserIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Teacher__UserIdU__75A278F5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.Codigo).IsRequired();

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.RoleIdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleIdRole);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
