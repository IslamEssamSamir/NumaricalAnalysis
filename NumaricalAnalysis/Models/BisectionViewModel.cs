using System.ComponentModel.DataAnnotations;

namespace NumaricalAnalysis.Models
{
    public enum MethodType { Bisection , FalsePosition}
    public class BisectionViewModel
    {
        [Required]
        public string equation { get; set; } = null!;

        [Required]
        public double XL { get; set; }

        [Required]
        public double XU { get; set; }

        [Range(0, 100 , ErrorMessage ="Range from 0 to 100 ..")]
        public double EPS { get; set; }


        public double? Root { get; set; }

        [Required]
        public MethodType methodType { get; set; }

        public List<Bisection> TableResult = new List<Bisection>();
    }
}
