

using SchoolItlaApp.Data.Base;

namespace SchoolItlaApp.Data.Entities
{
    public class Course : AuditEntity
    {
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
