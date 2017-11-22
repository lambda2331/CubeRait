using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cube.Models {
    public class User {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }

        [InverseProperty("User")]
        public ICollection<UsersRaiting> UserRaitings { get; set; }
    }

    public enum Role : byte {
        User = 1,
        Admin
    }
}
