using System.ComponentModel.DataAnnotations;

namespace Cube.Models {
    public class CubeModel {
        [Required]
        public CubeType TypeOfCube { get; set; }

        [Required]
        public double Time { get; set; }
    }
}
