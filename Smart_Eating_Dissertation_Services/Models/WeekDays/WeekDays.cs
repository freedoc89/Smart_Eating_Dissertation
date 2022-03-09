using Smart_Eating_Dissertation_Services.Models.Meals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Eating_Dissertation_Services.Models.WeekDays
{
    public class WeekDays
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Days { get; set; }
        public List<Breakfast_EatingData> Breakfast_eating_Foreignkey { get; set; } = new List<Breakfast_EatingData>();
        public List<Lunch_Soup_EatingData> Lunch_soup_eating_Foreignkey { get; set; } = new List<Lunch_Soup_EatingData>();
        public List<Lunch_Main_Course_EatingData> Lunch_main_eating_Foreignkey { get; set; } = new List<Lunch_Main_Course_EatingData>();

        public List<Dinner_EatingData> Dinner_eating_Foreignkey { get; set; } = new List<Dinner_EatingData>();


    }
}
