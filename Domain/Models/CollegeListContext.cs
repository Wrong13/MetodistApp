using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class CollegeListContext : DbContext
{
    public CollegeListContext()
    {
    }

    public CollegeListContext(DbContextOptions<CollegeListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    //public virtual DbSet<Student> Students { get; set; }

    //public virtual DbSet<TutStud> TutStuds { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<DbAdmin> DbAdmins { get; set; }

    public virtual DbSet<CollegeAdmin> CollegeAdmins { get; set; }
    public virtual DbSet<Attestation> Attestations { get; set; }
    public virtual DbSet<TrainingCourse> TrainingCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-G3QK2AT\\SQLEXPRESS;Initial Catalog=CollegeList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    
}
