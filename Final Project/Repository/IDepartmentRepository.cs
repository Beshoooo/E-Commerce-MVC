using Final_Project.Models;

namespace Final_Project.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetdeptById(int id);
        void Delete(int id);
        void Add(Department newdept);
        void Update(Department newdept, int id);
        List<Department> Search(string SearchName);
        void Save();
    }
}
