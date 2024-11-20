using System.ComponentModel.DataAnnotations;

namespace WreckRoad.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The passwords do not match!")]
        public string ConfirmPassword { get; set;}
    }
}
