using System.ComponentModel.DataAnnotations;

namespace Cube.Models {
    public class LogInUserModel {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
