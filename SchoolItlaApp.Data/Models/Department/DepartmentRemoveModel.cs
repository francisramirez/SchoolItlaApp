namespace SchoolItlaApp.Data.Models.Department
{

    public class DepartmentRemoveModel
    {
        public int DepartmentID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? UserDeleted { get; set; }
        public bool Deleted { get; set; }

    }
}
