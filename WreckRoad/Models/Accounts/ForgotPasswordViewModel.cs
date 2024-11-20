using System.ComponentModel.DataAnnotations;

namespace WreckRoad.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
