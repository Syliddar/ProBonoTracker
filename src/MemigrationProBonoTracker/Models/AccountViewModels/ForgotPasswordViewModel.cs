using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
