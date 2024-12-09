

using SchoolItlaApp.Data.Models.Department;

namespace SchoolItlaApp.Data.Interfaces
{
    public interface IDaoDepartment
    {
        void CreateDepartment(DepartmentCreateOrUpdateModel departmentCreateOrUpdate);
        void ModifyDepartment(DepartmentCreateOrUpdateModel departmentCreateOrUpdate);
        void RemoveDepartment(DepartmentRemoveModel departmentRemove);
        GetDepartmentModel GetDepartmentById(int departmentId);
        List<GetDepartmentModel> GetDepartments();
    }
}
