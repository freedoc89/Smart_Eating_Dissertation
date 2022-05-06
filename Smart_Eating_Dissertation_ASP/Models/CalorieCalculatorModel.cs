using System.ComponentModel.DataAnnotations;

namespace Smart_Eating_Dissertation_ASP.Models
{
    public class CalorieCalculatorModel
    {
        [Required]
        public string Gender { get; set; }
        [Required]
        [Range(0,100)]
        public int Age { get; set; }
        [Required]
        [Range(1,250)]
        public int Height { get; set; }
        [Required]
        [Range(1,300)]
        public int Weight { get; set; }
        [Range(1, 40)]
        public int BodyFat { get; set; }

        public string Target { get; set; }
    }
}
