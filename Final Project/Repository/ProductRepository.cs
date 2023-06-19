using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Repository
{
    public class ProductRepository:IProductRepository
    {
        MyContext context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductRepository(MyContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
             _webHostEnvironment=webHostEnvironment;
        }

    

        public void Add(Product newProduct,IFormFile imageFile)
        {
            if (imageFile != null)
            { 
            string fileName = Path.GetFileName(imageFile.FileName);

                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                { 
                imageFile.CopyTo(stream);
                }
                newProduct.Img = fileName;
            
            }
            context.Products.Add(newProduct);
        }

        public void Delete(int id)
        {
            Product oldProduct = GetProductById(id);
            oldProduct.Is_Deleted = 1;
        }

        public List<Product> GetAll()
        {

          return  context.Products.Where(o => o.Is_Deleted == 0).ToList();
        }
      


        public Product GetProductById(int id)
        {
            return context.Products.Where(p=>p.Is_Deleted==0).FirstOrDefault(d => d.Id == id);
        }

        public void Update(Product newProduct, int id, IFormFile imageFile)
        {
            if (imageFile != null&&imageFile.Length>0)
            {
                string fileName = Path.GetFileName(imageFile.FileName);

                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                newProduct.Img = fileName;

            }
            Product oldProduct= GetProductById(id);
            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.Description = newProduct.Description;
            oldProduct.Price= newProduct.Price;
            oldProduct.DeptId= newProduct.DeptId;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public List<Product> GetProductByDeptId(int id)
        {
            return context.Products.Where(o => o.Is_Deleted == 0 && o.DeptId==id).ToList();
        }

        public List<Product> Search(string SearchName)
        {
            List<Product> products;
            if (string.IsNullOrWhiteSpace(SearchName)) { products = context.Products.Where(o => o.Is_Deleted == 0).ToList(); }
            else { 
            products = context.Products.Where(o => o.Is_Deleted == 0&& o.ProductName.Contains(SearchName)).ToList();
            }
            return products;
        }

    
    }
}
