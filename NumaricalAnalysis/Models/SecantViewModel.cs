using FParsec;
using System.ComponentModel.DataAnnotations;

namespace NumaricalAnalysis.Models
{
    public class SecantViewModel
    {
        [Required]
        public string equation { get; set; } = null!;

        [Required]
        public double X0 { get; set; }


        [Required]
        public double XMinus1 { get; set; }



        [Range(0, 100, ErrorMessage = "Range from 0 to 100 ..")]
        public double EPS { get; set; }


        public double? Root { get; set; }



        public List<Secant> TableResult = new List<Secant>();
    }
}
