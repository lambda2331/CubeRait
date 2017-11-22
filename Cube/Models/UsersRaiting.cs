using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cube.Models {
    [Table("UsersRaitings")]
    public class UsersRaiting {
        [Key]
        public int UserRaitingId { get; set; }
        public CubeType TypeOfCube { get; set; }
        public double Time { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum CubeType {
        Cube2 = 2,
        Cube3,
        Cube4,
        Cube5,
        Cube6,
        Cube7
    }
}
