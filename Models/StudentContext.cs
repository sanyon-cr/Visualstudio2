using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Student.Models;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<StudentDetailsNoCombined> StudentDetailsNoCombineds { get; set; }

    public virtual DbSet<StudentGrade> StudentGrades { get; set; }

    public virtual DbSet<StudentGradeNoCombined> StudentGradeNoCombineds { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherNoCombined> TeacherNoCombineds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-009QH7Q9;Initial Catalog=Student;Integrated Security=True;TrustServerCertificate=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student___A2F4E98C270B7942");

            entity.ToTable("Student_Details");

            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
            entity.Property(e => e.TeacherId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('NA')")
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValueSql("('Mr')")
                .IsFixedLength();

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.CourseCode)
                .HasConstraintName("FK__Student_D__Cours__47DBAE45");

            entity.HasOne(d => d.Teacher).WithMany(p => p.StudentDetails)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_TeacherId");
        });

        modelBuilder.Entity<StudentDetailsNoCombined>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student___A2F4E98CF12B577D");

            entity.ToTable("Student_Details_no_Combined");

            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Student_Name");
            entity.Property(e => e.TeacherId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<StudentGrade>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Student___FC00E0017DC288D9");

            entity.ToTable("Student_Grade");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<StudentGradeNoCombined>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Student___FC00E001D6F365BD");

            entity.ToTable("Student_Grade_no_Combined");

            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CourseTitle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grade).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF259647932981E");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("('NA')")
                .IsFixedLength();
            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TeacherNoCombined>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher___EDF259641A57A0E5");

            entity.ToTable("Teacher_no_Combined");

            entity.Property(e => e.TeacherId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
