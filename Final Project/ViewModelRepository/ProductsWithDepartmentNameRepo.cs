using Final_Project.Models;
using Final_Project.Repository;
using Final_Project.ViewModels;

namespace Final_Project.ViewModelRepository
{
    public class ProductsWithDepartmentNameRepo : IProductWithDepartmentName
    {
       MyContext context;
        public ProductsWithDepartmentNameRepo(MyContext db) {
            context = db;
            
        }
      

        List<ProductsWithDepartmentName> IProductWithDepartmentName.GetAll()
        {
            List<Product> products = context.Products.Where(p=>p.Is_Deleted==0).ToList();
            List<Department> departments = context.Departments.Where(p => p.Is_Deleted == 0).ToList();


            List<ProductsWithDepartmentName> productsWithDepartmentName = new List<ProductsWithDepartmentName>();
            foreach (var item in products)
            {
                productsWithDepartmentName.Add(new ProductsWithDepartmentName
                {
                    Id = item.Id,
                    Img = item.Img,
                    DeptId = item.DeptId,
                    Description = item.Description,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    DepartmentName = departments.Where(p => p.Id == item.DeptId).Select(p => p.DepartmentName).SingleOrDefault()
                });
            };

            return productsWithDepartmentName;


        }

        public List<ProductsWithDepartmentName> Search(string SearchName)
        {
            List<Product> products;
            List<Department> departments = context.Departments.ToList();
            if (string.IsNullOrWhiteSpace(SearchName)) { products = context.Products.Where(o => o.Is_Deleted == 0).ToList(); }
            else
            {
                products = context.Products.Where(o => o.Is_Deleted == 0 && o.ProductName.Contains(SearchName)).ToList();
            }
            List<ProductsWithDepartmentName> productsWithDepartmentName = new List<ProductsWithDepartmentName>();
            foreach (var item in products)
            {
                productsWithDepartmentName.Add(new ProductsWithDepartmentName
                {
                    Id = item.Id,
                    Img = item.Img,
                    DeptId = item.DeptId,
                    Description = item.Description,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    DepartmentName = departments.Where(p => p.Id == item.DeptId).Select(p => p.DepartmentName).SingleOrDefault()
                });
            };
            return productsWithDepartmentName;
        }
    }
}
