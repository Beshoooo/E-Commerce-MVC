using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Models;
using Final_Project.Repository;

namespace Final_Project.Controllers
{// [Authorize(Roles =("Admin,SV")]
    public class ProductController : Controller
    {
       
        IProductRepository ProductRepository;
        IDepartmentRepository departmentRepository;

     

        public ProductController(IProductRepository prodRepo, IDepartmentRepository DeptRepo)
        {
            departmentRepository = DeptRepo;
            ProductRepository = prodRepo;

        }

        [AllowAnonymous]

        public IActionResult Index()
        {
            
            List<Product> prodListModel = ProductRepository.GetAll();
            return View(prodListModel);

        }
        [AllowAnonymous]

        public IActionResult GetById(int id)
        {

            Product prodModel = ProductRepository.GetProductById(id);
            return View(prodModel);

        }

        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View(new Product());
        }
        [HttpPost]//Form 
        public IActionResult SaveAdd(Product prod, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    ProductRepository.Add(prod,imageFile);
                    ProductRepository.Save();
                    return RedirectToAction("Index", "Dashboard");
                }
                catch (Exception ex)
                {


                    ModelState.AddModelError(string.Empty, ex.Message.ToString());

                }

            }

            ViewData["DeptList"] = departmentRepository.GetAll();
            return View("New", prod);

        }

        public IActionResult Edit(int id)
        {

            Product prodmodel = ProductRepository.GetProductById(id);
                //db.Products.FirstOrDefault(I => I.Id == id);
            ViewData["DeptList"] = departmentRepository.GetAll();
                //db.Departments.ToList();
            return View("Edit",prodmodel);
        }

        [HttpPost]
        public IActionResult SaveEdit(int id, Product newprod , IFormFile imageFile)
        {
             Product oldcrs = ProductRepository.GetProductById(id);
            if (ModelState.IsValid)
            {
                if (oldcrs != null)
                {
                    ProductRepository.Update(newprod, id,imageFile);
                    ProductRepository.Save();
                    return RedirectToAction("Index", "Dashboard");

                }
            }
            ViewData["DeptList"] = departmentRepository.GetAll();
            return View("Edit", newprod);
        }
        public IActionResult Remove(int id)
        {

            ProductRepository.Delete(id);
            ProductRepository.Save();
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Search(string query)
        {

           if (query != null )
            {

            List<Product> prod = ProductRepository.Search(query);
            return View("Index", prod);

            }else{
                List<Product> prod = ProductRepository.GetAll();
                return View("Index",prod);
          
                }
        }  
 
        public IActionResult GetProdByDept(int deptid)
        {
            List<Product> prod = ProductRepository.GetProductByDeptId(deptid);
            return View("Index",prod);
        }

    }
}
