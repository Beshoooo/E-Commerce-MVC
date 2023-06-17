using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
