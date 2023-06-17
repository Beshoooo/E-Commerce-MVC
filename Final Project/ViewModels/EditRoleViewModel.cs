using Microsoft.Build.Framework;

namespace Final_Project.ViewModels
{
    public class EditRoleViewModel
    {
        public string RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
        
    }
}
