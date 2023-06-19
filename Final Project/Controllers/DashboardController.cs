using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Models;
using Final_Project.ViewModels;
using Final_Project.Repository;
using Final_Project.ViewModelRepository;

namespace Final_Project.Controllers
{
    // [Authorize(Roles =("Admin,SV")]
    public class DashboardController : Controller
    {
        IProductRepository ProductRepository;
        IDepartmentRepository departmentRepository;
        IProductWithDepartmentName productWithDepartmentNameRepository;
        public DashboardController(IProductRepository _productRepository,IDepartmentRepository _departmentRepository,IProductWithDepartmentName _p) {
        
        this.ProductRepository = _productRepository;
            this.departmentRepository = _departmentRepository;
            productWithDepartmentNameRepository = _p;
        }
        public IActionResult Index()
        {
          
            return View(productWithDepartmentNameRepository.GetAll());
        }
        public IActionResult MangingDepartment()
        {
 
            return View(departmentRepository.GetAll());
        }

        public IActionResult Search(string query)
        {

            if (query != null)
            {

                List<ProductsWithDepartmentName> prod = productWithDepartmentNameRepository.Search(query);
                return View("Index", prod);

            }
            else
            {
                List<ProductsWithDepartmentName> prod = productWithDepartmentNameRepository.GetAll();
                return View("Index", prod);

            }
        }
        public IActionResult SearchDepartment(string query)
        {

            if (query != null)
            {

                List<Department> prod = departmentRepository.Search(query);
                return View("MangingDepartment", prod);

            }
            else
            {
                List<Department> prod = departmentRepository.GetAll();
                return View("MangingDepartment", prod);

            }
        }
    }
}
