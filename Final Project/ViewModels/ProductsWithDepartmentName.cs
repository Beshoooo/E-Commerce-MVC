using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.ViewModels
{
    public class ProductsWithDepartmentName
    {
        public int Id { get; set; }
        public String? ProductName { get; set; }
        public int? Price { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
