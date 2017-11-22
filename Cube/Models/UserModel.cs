using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cube.Models
{
    public class UserModel {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}