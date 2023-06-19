
using Final_Project.ViewModels;

namespace Final_Project.ViewModelRepository
{
    public interface IProductWithDepartmentName
    {
        List<ProductsWithDepartmentName> GetAll();
        List<ProductsWithDepartmentName> Search(string SearchName);
    }
}
