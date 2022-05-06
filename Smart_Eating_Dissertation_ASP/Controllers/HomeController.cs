using Microsoft.AspNetCore.Mvc;
using Smart_Eating_Dissertation_ASP.Models;
using Smart_Eating_Dissertation_Services.Data;
using System.Diagnostics;

namespace Smart_Eating_Dissertation_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        Random random_meals = new Random();

        //Reggeli randomolása
        public IActionResult rand_breakfast()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            int count = _context.breakfast_EatingDatas_DB.Count();
            int index = random_meals.Next(1, count+1);
            var breakfast = _context.breakfast_EatingDatas_DB.Where(x => x.Id == index);
            if (breakfast.Count() > 0)
            {
                foreach (var item in breakfast)
                {
                    TempData["breakfast"] = item.Name_of_food.ToString();
                    TempData["breakfast_protein"] = item.Protein_weight.ToString() + "g";
                    TempData["breakfast_fat"] = item.Fat_weight.ToString() + "g";
                    TempData["breakfast_carbohydrate"] = item.Carbohydrate_weight.ToString() + "g";
                    TempData["breakfast_kcal"] = item.Calorie_kcal.ToString() + "Kcal";
                }
            }
            else
            {
                TempData["breakfast"] = "A reggelik adatbázisa nem elérhető!";
            }

            return RedirectToAction("Index", "Home");
        }
        //Leves randomolása
        public IActionResult rand_soup()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            int count = _context.lunch_Soup_EatingDatas_DB.Count();
            int index = random_meals.Next(1, count+1);
            var soup = _context.lunch_Soup_EatingDatas_DB.Where(x => x.Id == index);
            if (soup.Count() > 0)
            {
                foreach (var item in soup)
                {
                    TempData["soup"] = item.Name_of_food.ToString();
                    TempData["soup_protein"] = item.Protein_weight.ToString() + "g";
                    TempData["soup_fat"] = item.Fat_weight.ToString() + "g";
                    TempData["soup_carbohydrate"] = item.Carbohydrate_weight.ToString() + "g";
                    TempData["soup_kcal"] = item.Calorie_kcal.ToString() + "Kcal";
                }
            }
            else
            {
                TempData["soup"] = "A levesek adatbázisa nem elérhető!";
            }

            return RedirectToAction("Index", "Home");
        }
        //Főétel randomolása
        public IActionResult rand_maincourse()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            int count = _context.lunch_Main_Course_EatingDatas_DB.Count();
            int index = random_meals.Next(1, count+1);
            var main_course = _context.lunch_Main_Course_EatingDatas_DB.Where(x => x.Id == index);
            if (main_course.Count() > 0)
            {
                foreach (var item in main_course)
                {
                    TempData["main_course"] = item.Name_of_food.ToString();
                    TempData["main_course_protein"] = item.Protein_weight.ToString() + "g";
                    TempData["main_course_fat"] = item.Fat_weight.ToString() + "g";
                    TempData["main_course_carbohydrate"] = item.Carbohydrate_weight.ToString() + "g";
                    TempData["main_course_kcal"] = item.Calorie_kcal.ToString() + "Kcal";
                }
            }
            else
            {
                TempData["main_course"] = "A főételek adatbázisa nem elérhető!";
            }

            return RedirectToAction("Index", "Home");
        }
        //Vacsora randomolása
        public IActionResult rand_dinner()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            int count = _context.dinner_EatingDatas_DB.Count();
            int index = random_meals.Next(1, count+1);
            var dinner = _context.dinner_EatingDatas_DB.Where(x => x.Id == index);
            if (dinner.Count() > 0)
            {
                foreach (var item in dinner)
                {
                    TempData["dinner"] = item.Name_of_food.ToString();
                    TempData["dinner_protein"] = item.Protein_weight.ToString() + "g";
                    TempData["dinner_fat"] = item.Fat_weight.ToString() + "g";
                    TempData["dinner_carbohydrate"] = item.Carbohydrate_weight.ToString() + "g";
                    TempData["dinner_kcal"] = item.Calorie_kcal.ToString() + "Kcal";
                }
            }
            else
            {
                TempData["dinner"] = "A vacsorák adatbázisa nem elérhető!";
            }

            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}