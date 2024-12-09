

using Microsoft.Extensions.Logging;
using SchoolItlaApp.Data.Context;
using SchoolItlaApp.Data.Entities;
using SchoolItlaApp.Data.Exceptions;
using SchoolItlaApp.Data.Interfaces;
using SchoolItlaApp.Data.Models.Department;
using System.Collections.Generic;

namespace SchoolItlaApp.Data.Daos
{
    public class DaoDepartment : IDaoDepartment
    {
        private readonly SchoolContext _context;
        private readonly ILogger<DaoDepartment> _logger;

        public DaoDepartment(SchoolContext context, ILogger<DaoDepartment> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void CreateDepartment(DepartmentCreateOrUpdateModel departmentCreateOrUpdate)
        {
            try
            {
                if (departmentCreateOrUpdate is null)
                    // Lanzar la excepcion //
                    throw new DepartmentDaoException("Debe suministrar el parametro.");


                Department department = new Department()
                {
                    Administrator = departmentCreateOrUpdate.Administrator,
                    Budget = departmentCreateOrUpdate.Budget,
                    CreationUser = departmentCreateOrUpdate.UserId,
                    CreationDate = departmentCreateOrUpdate.ChangeDate,
                    Name = departmentCreateOrUpdate.Name,
                    StartDate = departmentCreateOrUpdate.StartDate
                };

                _context.Departments.Add(department);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error creando un departamento", ex.ToString());
            }
        }

        public GetDepartmentModel GetDepartmentById(int departmentId)
        {
            GetDepartmentModel departmentFound = new GetDepartmentModel();

            try
            {


                Department? department = _context.Departments.Find(departmentId);

                departmentFound.Id = department.DepartmentID;
                departmentFound.Administrator = department.Administrator;
                departmentFound.Budget = department.Budget;
                departmentFound.Name = department.Name;
                departmentFound.StartDate = department.StartDate;
                departmentFound.CreateDate = department.CreationDate;

            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error obteniendo un departamento", ex.ToString());
            }

            return departmentFound;
        }

        public List<GetDepartmentModel> GetDepartments()
        {
            List<GetDepartmentModel> departmentsList = new List<GetDepartmentModel>();
            try
            {
                departmentsList = (from department in _context.Departments
                                   where department.Deleted == false
                                   orderby department descending
                                   select new GetDepartmentModel()
                                   {
                                       Administrator = department.Administrator,
                                       Budget = department.Budget,
                                       CreateDate = department.CreationDate,
                                       Id = department.DepartmentID,
                                       Name = department.Name,
                                       StartDate = department.StartDate,
                                   }).ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error obteniendo los departamentos", ex.ToString());
            }
            return departmentsList;
        }

        public void ModifyDepartment(DepartmentCreateOrUpdateModel departmentCreateOrUpdate)
        {
            try
            {
                Department? departmentToUpdate = _context.Departments.Find(departmentCreateOrUpdate.DepartmentID);

                departmentToUpdate.Name = departmentCreateOrUpdate.Name;
                departmentToUpdate.StartDate = departmentCreateOrUpdate.StartDate;
                departmentToUpdate.ModifyDate = departmentCreateOrUpdate.ChangeDate;
                departmentToUpdate.UserMod = departmentCreateOrUpdate.UserId;
                departmentToUpdate.Administrator = departmentCreateOrUpdate.Administrator;
                departmentToUpdate.Budget = departmentCreateOrUpdate.Budget;
                
                _context.Departments.Update(departmentToUpdate);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error obteniendo los departamentos", ex.ToString());
            }
        }

        public void RemoveDepartment(DepartmentRemoveModel departmentRemove)
        {
            try
            {
                Department? departmentToRemove= _context.Departments.Find(departmentRemove.DepartmentID);

                departmentToRemove.DeletedDate= departmentRemove.DeletedDate;
                departmentToRemove.Deleted = true;
                departmentToRemove.UserDeleted= departmentRemove.UserDeleted;

                _context.Departments.Update(departmentToRemove);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                _logger.LogError("Ocurrió un error obteniendo los departamentos", ex.ToString());
            }
        }
    }
}
