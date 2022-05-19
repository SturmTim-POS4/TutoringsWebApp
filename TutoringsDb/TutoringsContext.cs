using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TutoringsDb
{
    public partial class TutoringsContext : DbContext
    {
        public TutoringsContext()
        {
        }

        public TutoringsContext(DbContextOptions<TutoringsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clazz> Clazzs { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Tutoring> Tutorings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\mssqllocaldb;attachdbfilename=C:\\Users\\timst\\Desktop\\Schule\\createwebapiproject\\tutorings.mdf;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.ClazzId, "IX_Clazz_Id");

                entity.Property(e => e.ClazzId).HasColumnName("Clazz_Id");

                entity.HasOne(d => d.Clazz)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClazzId)
                    .HasConstraintName("FK_dbo.Students_dbo.Clazzs_Clazz_Id");
            });

            modelBuilder.Entity<Tutoring>(entity =>
            {
                entity.HasIndex(e => e.StudentId, "IX_Student_Id");

                entity.HasIndex(e => e.SubjectId, "IX_Subject_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Tutorings)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Tutorings_dbo.Students_Student_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Tutorings)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.Tutorings_dbo.Subjects_Subject_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
