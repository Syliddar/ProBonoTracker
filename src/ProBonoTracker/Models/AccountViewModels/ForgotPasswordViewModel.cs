using System.ComponentModel.DataAnnotations;

namespace ProBonoTracker.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
