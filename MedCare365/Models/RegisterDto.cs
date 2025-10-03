using System.ComponentModel.DataAnnotations;

namespace MedCare365.Models
{
    public class RegisterDto
    {
        [Key]
        public int userId;

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
