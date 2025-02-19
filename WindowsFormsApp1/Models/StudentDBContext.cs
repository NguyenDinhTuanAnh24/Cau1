using System.Data.Entity;
using WindowsFormsApp1.Models;

public class StudentDBContext : DbContext
{
    public StudentDBContext() : base("StudentDBContext") { }

    public DbSet<Student> Students { get; set; }
}