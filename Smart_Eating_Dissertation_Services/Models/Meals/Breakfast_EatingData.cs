using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Eating_Dissertation_Services.Models.Meals
{
    public class Breakfast_EatingData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name_of_food { get; set; }

        [Required]
        public double Protein_weight { get; set; }

        [Required]
        public double Fat_weight { get; set; }

        [Required]
        public double Carbohydrate_weight { get; set; }

        [Required]
        public double Calorie_kcal { get; set; }
    }
}
