using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smart_Eating_Dissertation_ASP.Models;
using Smart_Eating_Dissertation_Services.Data;

namespace Smart_Eating_Dissertation_ASP.Controllers
{
    public class CalorieController : Controller
    {

        public IActionResult Index()
        {            
            return View();
        }       
        
    }
}
