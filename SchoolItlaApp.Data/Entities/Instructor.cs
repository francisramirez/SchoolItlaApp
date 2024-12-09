

using SchoolItlaApp.Data.Base;

namespace SchoolItlaApp.Data.Entities
{
    public class Instructor : Person
    {
        public int Id { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
