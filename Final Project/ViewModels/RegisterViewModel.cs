using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="RePassword")]
        [Compare("Password",ErrorMessage = "Confirm Password Not Match Password")]
        public string ConfirmPassword { get; set; }
        [StringLength(11)]
        public string PhoneNumber { get; set; }


    }
}
