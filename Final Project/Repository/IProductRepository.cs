using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProductById(int id);
        List<Product> GetProductByDeptId(int id);

       
        void Delete(int id);
        void Add(Product newProduct, IFormFile imageFile);
        void Update(Product newProduct, int id, IFormFile? imageFile);

        List<Product> Search(string SearchName);

        void Save();
    }
}
