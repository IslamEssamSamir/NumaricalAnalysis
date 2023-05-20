using FParsec;
using System.ComponentModel.DataAnnotations;

namespace NumaricalAnalysis.Models
{
    public class SimpleFixedPointViewModel
    {
        [Required]
        public string equation { get; set; } = null!;

        [Required]
        public double Xi { get; set; }



        [Range(0, 100, ErrorMessage = "Range from 0 to 100 ..")]
        public double EPS { get; set; }


        public double? Root { get; set; }

       
        public List<SimpleFixedPoint> TableResult = new List<SimpleFixedPoint>();
    }
}
