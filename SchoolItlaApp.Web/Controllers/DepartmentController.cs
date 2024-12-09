using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolItlaApp.Data.Interfaces;
using SchoolItlaApp.Data.Models.Department;

namespace SchoolItlaApp.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDaoDepartment _daoDepartment;

        public DepartmentController(IDaoDepartment daoDepartment)
        {
            _daoDepartment = daoDepartment;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var department = _daoDepartment.GetDepartments();
            return View(department);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var department = _daoDepartment.GetDepartmentById(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentCreateOrUpdateModel createModel)
        {
            try
            {
                createModel.UserId = 1;
                createModel.ChangeDate = DateTime.Now;
                _daoDepartment.CreateDepartment(createModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {

            var department = _daoDepartment.GetDepartmentById(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentCreateOrUpdateModel updateModel)
        {
            try
            {
                updateModel.UserId = 1;
                updateModel.ChangeDate = DateTime.Now;
                _daoDepartment.ModifyDepartment(updateModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

       
    }
}
