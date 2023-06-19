using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(15)]
        [MinLength(3)]
        public String? ProductName { get; set; }
        [Range(1,50000)]
        public int? Price { get; set; }

        //[RegularExpression(@"^\w[1-9]*\.(jpg|png|gif)$",
        //ErrorMessage = "Image must be jpg ,png or gif")]
        public string? Img { get; set; }
        [MaxLength(35)]
        [MinLength(3)]
        public string? Description { get; set; }
        [ForeignKey("Department")]
        public int? DeptId { get; set; }

        public int Is_Deleted { get; set; } = 0;

        public virtual Department? Department { get; set; }
    }
}
