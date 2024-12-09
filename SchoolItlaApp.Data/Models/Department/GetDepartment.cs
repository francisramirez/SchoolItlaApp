 

namespace SchoolItlaApp.Data.Models.Department
{
    public class GetDepartmentModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public int? Administrator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
