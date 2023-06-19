using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MyContext context;
        public DepartmentRepository(MyContext _context)
        {
            this.context = _context;
            
        }

        public List<Department> GetAll()
        {
            return context.Departments.Where(o => o.Is_Deleted == 0).ToList();
        }


        public Department GetdeptById(int Id)
        {
            return context.Departments.Where(o=>o.Is_Deleted==0).FirstOrDefault(d => d.Id == Id);
        }


        public void Add(Department newdept)
        {
            context.Departments.Add(newdept);
        }

        public void Delete(int id)
        {
            Department oldDept = GetdeptById(id);
            oldDept.Is_Deleted = 1;
        }

        
        public void Update(Department newdept, int id)
        {
            Department oldDept = GetdeptById(id);

            oldDept.DepartmentName = newdept.DepartmentName;
            oldDept.DeptManger = newdept.DeptManger;
            oldDept.DepartmentIcon = newdept.DepartmentIcon;
            oldDept.DeptManger_Id = newdept.DeptManger_Id;
        }
     

        public void Save()
        {
            context.SaveChanges();
        }

        public List<Department> Search(string SearchName)
        {
            List<Department> departments;
            if (string.IsNullOrWhiteSpace(SearchName)) { departments = context.Departments.Where(o => o.Is_Deleted == 0).ToList(); }
            else
            {
                departments = context.Departments.Where(o => o.Is_Deleted == 0 && o.DepartmentName.Contains(SearchName)).ToList();
            }
            return departments;
        }

    }
}
