

using Microsoft.EntityFrameworkCore;
using SchoolItlaApp.Data.Entities;

namespace SchoolItlaApp.Data.Context
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
