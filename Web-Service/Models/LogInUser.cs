using System.ComponentModel.DataAnnotations;

namespace Web_Service.Models
{
    public class LogInUser
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }



    }
}
