using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(3)]
        public string? DepartmentName { get; set; }
        public string? DepartmentIcon { get; set; }
        [MaxLength(20)]
        [MinLength(3)]
        public string? DeptManger { get; set; }
        public string? DeptManger_Id { get; set; }
        public int Is_Deleted { get; set; } 

        public virtual List<Product>? Products { get; set; }
    }
}
