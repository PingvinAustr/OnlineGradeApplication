using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineGradeApplication_DAL.Entities;

public partial class OnlineGradesDbContext : DbContext
{
    public OnlineGradesDbContext()
    {
    }

    public OnlineGradesDbContext(DbContextOptions<OnlineGradesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }

    public virtual DbSet<Cafedra> Cafedras { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }

    public virtual DbSet<StudentCard> StudentCards { get; set; }

    public virtual DbSet<StudentMark> StudentMarks { get; set; }

    public virtual DbSet<StudentStatus> StudentStatuses { get; set; }

    public virtual DbSet<StudentsGroup> StudentsGroups { get; set; }

    public virtual DbSet<SystemAccess> SystemAccesses { get; set; }

    public virtual DbSet<TeacherCard> TeacherCards { get; set; }

    public virtual DbSet<TeacherPosition> TeacherPositions { get; set; }

    public virtual DbSet<TeachersGroup> TeachersGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-77MT8LVK;Database=OnlineGradesDb;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Assignme__3214EC076CE7524E");

            entity.Property(e => e.AssignmentName).HasMaxLength(150);
        });

        modelBuilder.Entity<Cafedra>(entity =>
        {
            entity.HasKey(e => e.CafedraId).HasName("PK__Cafedra__CC57CCC83B571C6A");

            entity.ToTable("Cafedra");

            entity.Property(e => e.CafedraName).HasMaxLength(300);
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discipli__3214EC07C61D61B7");

            entity.Property(e => e.DisciplineName).HasMaxLength(200);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF36ACCB9DBE8");

            entity.Property(e => e.GroupName).HasMaxLength(200);

            entity.HasOne(d => d.GroupCafedra).WithMany(p => p.Groups)
                .HasForeignKey(d => d.GroupCafedraId)
                .HasConstraintName("FK__Groups__GroupCaf__4222D4EF");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC07032C7C4A");

            entity.Property(e => e.FirstName).HasMaxLength(200);
            entity.Property(e => e.LastName).HasMaxLength(200);
            entity.Property(e => e.SecondName).HasMaxLength(200);

            entity.HasOne(d => d.Role).WithMany(p => p.People)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Persons__RoleId__3A81B327");

            entity.HasOne(d => d.SystemAccess).WithMany(p => p.People)
                .HasForeignKey(d => d.SystemAccessId)
                .HasConstraintName("FK__Persons__SystemA__6EF57B66");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A3E2B31AD");

            entity.Property(e => e.RoleName).HasMaxLength(200);
        });

        modelBuilder.Entity<StudentAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentA__3214EC0730723896");

            entity.HasOne(d => d.AssignmentType).WithMany(p => p.StudentAssignments)
                .HasForeignKey(d => d.AssignmentTypeId)
                .HasConstraintName("FK__StudentAs__Assig__5DCAEF64");

            entity.HasOne(d => d.CreatedByTeacher).WithMany(p => p.StudentAssignmentCreatedByTeachers)
                .HasForeignKey(d => d.CreatedByTeacherId)
                .HasConstraintName("FK__StudentAs__Creat__5BE2A6F2");

            entity.HasOne(d => d.ResponsibleTeacher).WithMany(p => p.StudentAssignmentResponsibleTeachers)
                .HasForeignKey(d => d.ResponsibleTeacherId)
                .HasConstraintName("FK__StudentAs__Respo__5CD6CB2B");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAssignmentStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentAs__Stude__5AEE82B9");
        });

        modelBuilder.Entity<StudentCard>(entity =>
        {
            entity.HasKey(e => e.StudentCardId).HasName("PK__StudentC__29ABE76B6C477940");

            entity.Property(e => e.CourseWorkTopicBachelor).HasMaxLength(250);
            entity.Property(e => e.CourseWorkTopicMaster).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(75);
            entity.Property(e => e.FatherName).HasMaxLength(150);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MotherName).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.CourseWorkLeaderBachelorNavigation).WithMany(p => p.StudentCardCourseWorkLeaderBachelorNavigations)
                .HasForeignKey(d => d.CourseWorkLeaderBachelor)
                .HasConstraintName("FK__StudentCa__Cours__4E88ABD4");

            entity.HasOne(d => d.CourseWorkLeaderMasterNavigation).WithMany(p => p.StudentCardCourseWorkLeaderMasterNavigations)
                .HasForeignKey(d => d.CourseWorkLeaderMaster)
                .HasConstraintName("FK__StudentCa__Cours__4F7CD00D");

            entity.HasOne(d => d.StudentStatus).WithMany(p => p.StudentCards)
                .HasForeignKey(d => d.StudentStatusId)
                .HasConstraintName("FK__StudentCa__Stude__4D94879B");
        });

        modelBuilder.Entity<StudentMark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentM__3214EC07EEE4EFC7");

            entity.HasOne(d => d.Assignment).WithMany(p => p.StudentMarks)
                .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK__StudentMa__Assig__619B8048");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentMarks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentMa__Assig__60A75C0F");
        });

        modelBuilder.Entity<StudentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentS__3214EC07BA9441BE");

            entity.Property(e => e.StatusName).HasMaxLength(150);
        });

        modelBuilder.Entity<StudentsGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07B2F8BC2C");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__StudentsG__Group__48CFD27E");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentsG__Stude__47DBAE45");
        });

        modelBuilder.Entity<SystemAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SystemAc__3214EC0756AFA2BF");

            entity.ToTable("SystemAccess");

            entity.Property(e => e.UserPassword).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<TeacherCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherC__3214EC0703054155");

            entity.ToTable("TeacherCard");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);

            entity.HasOne(d => d.Cafedra).WithMany(p => p.TeacherCards)
                .HasForeignKey(d => d.CafedraId)
                .HasConstraintName("FK__TeacherCa__Cafed__6B24EA82");

            entity.HasOne(d => d.Position).WithMany(p => p.TeacherCards)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__TeacherCa__Posit__6C190EBB");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherCards)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherCa__Teach__6A30C649");
        });

        modelBuilder.Entity<TeacherPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherP__3214EC079653FC75");

            entity.Property(e => e.PositionName).HasMaxLength(250);
        });

        modelBuilder.Entity<TeachersGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07927EB03B");

            entity.HasOne(d => d.Discipline).WithMany(p => p.TeachersGroups)
                .HasForeignKey(d => d.DisciplineId)
                .HasConstraintName("FK__TeachersG__Disci__5629CD9C");

            entity.HasOne(d => d.Group).WithMany(p => p.TeachersGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__TeachersG__Group__5441852A");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeachersGroups)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeachersG__Teach__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
