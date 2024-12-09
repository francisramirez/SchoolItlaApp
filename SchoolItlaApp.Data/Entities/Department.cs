

using SchoolItlaApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolItlaApp.Data.Entities
{
    [Table("Departments")]
    public class Department : AuditEntity
    {
        [Key]
        public int DepartmentID { get; set; }
         
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
    }
}
