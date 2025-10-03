using System.ComponentModel.DataAnnotations;

namespace MedCare365.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage ="username is required")]
        public string? userName { get; set; } = null;
        [Required(ErrorMessage ="email is required")]
        [EmailAddress]
        public string? email { get; set; } = null;

        [Phone]
        public string? phone { get; set; }

        [Required]
        public string? password { get; set; }

    }
}
