
using SchoolItlaApp.Data.Base;


namespace SchoolItlaApp.Data.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
