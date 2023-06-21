using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Models;
using Final_Project.Repository;
using Final_Project.ViewModelRepository;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace Final_Project.Controllers
{
    public class DepartmentController : Controller
    {
      
        IProductRepository ProductRepository;
        IDepartmentRepository departmentRepository;
        IProductWithDepartmentName productWithDepartmentNameRepository;

       
        public DepartmentController(IProductRepository prodRepo, IDepartmentRepository DeptRepo,IProductWithDepartmentName _p)
        {
            departmentRepository = DeptRepo;
            ProductRepository = prodRepo;
            productWithDepartmentNameRepository = _p;

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["ProductsList"] = productWithDepartmentNameRepository.GetAll();
            List<Department> deptListModel = departmentRepository.GetAll();
            return View(deptListModel);

        }
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {

            Department deptModel = departmentRepository.GetdeptById(id);
            ViewData["id"]=id;
            return View(deptModel);

        }

        [HttpGet]
        [Authorize(Roles = "Admin,SV")]
        public IActionResult New()
        {
           
            return View(new Department());
        }
        [HttpPost]//Form 
        [Authorize(Roles = "Admin,SV")]
        public IActionResult SaveAdd(Department dept)
        {
            if (ModelState.IsValid&&dept!=null)
            {
                try
                {
                    departmentRepository.Add(dept);
                    departmentRepository.Save();
                    return RedirectToAction("MangingDepartment","Dashboard");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }
            }
            return View("New", dept);
        }

        [Authorize(Roles = "Admin,SV")]
        public IActionResult Edit(int id)
        {

            Department prodmodel = departmentRepository.GetdeptById(id);
                //db.Departments.FirstOrDefault(I => I.Id == id);
            //ViewData["prodtList"] = db.Products.ToList();
            return View(prodmodel);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,SV")]
        public IActionResult SaveEdit(int id, Department newdept)
        {

            if (ModelState.IsValid&&newdept!=null)
            {

                Department olddept = departmentRepository.GetdeptById(id);
                if (olddept != null)
                {
                    departmentRepository.Update(newdept, id);
                    departmentRepository.Save();
                    return RedirectToAction("MangingDepartment", "Dashboard");

                }
            }
            //ViewData["prodList"] = db.Products.ToList();
            return View("Edit", newdept);
        }

        [Authorize(Roles = "Admin,SV")]
        public IActionResult Remove(int id)
        {

            departmentRepository.Delete(id);
            departmentRepository.Save();
            return RedirectToAction("MangingDepartment", "Dashboard");
        }

        [AllowAnonymous]
        public IActionResult PartialProductResult(int deptId)
        {

            List<Product> product = ProductRepository.GetProductByDeptId(deptId);

            return PartialView("_ShowAllProudctsPartial",product);
        }

    }
}
