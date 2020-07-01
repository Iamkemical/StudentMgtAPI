using Microsoft.EntityFrameworkCore;
using StudentMgtAPI.Models;

namespace StudentMgtAPI.DatabaseContext
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<StudentModel> Student { get; set; }
    }
}