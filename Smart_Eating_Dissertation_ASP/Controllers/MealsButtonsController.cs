using Microsoft.AspNetCore.Mvc;
using Smart_Eating_Dissertation_Services.Data;

namespace Smart_Eating_Dissertation_ASP.Controllers
{
    public class MealsButtonsController : Controller
    {
        Random random_meals = new Random();

        public IActionResult rand_breakfast()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            int count = _context.breakfast_EatingDatas_DB.Count();
            int index = random_meals.Next(1, count);
            var breakfast = _context.breakfast_EatingDatas_DB.Where(x => x.Id == index);
            if (breakfast.Count() > 0)
            {
                foreach (var item in breakfast)
                {
                    TempData["breakfast"] = item.Name_of_food.ToString();
                    TempData["protein"] = item.Protein_weight.ToString() + "g";
                    TempData["fat"] = item.Fat_weight.ToString() + "g";
                    TempData["carbohydrate"] = item.Carbohydrate_weight.ToString() + "g";
                    TempData["kcal"] = item.Calorie_kcal.ToString() + "Kcal";
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult rand_soup()
        {

            return View();
        }
    }
}
