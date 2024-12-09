namespace SchoolItlaApp.Data.Models.Department
{
    public class DepartmentCreateOrUpdateModel
    {
        public int DepartmentID { get { return this.Id; } }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? Administrator { get; set; }
        public int UserId { get; set; }
        public DateTime ChangeDate { get; set; }
        public int Id { get; set; }
    }
}
