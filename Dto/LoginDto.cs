using System.ComponentModel.DataAnnotations;

namespace CargoCompany.Dto
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}