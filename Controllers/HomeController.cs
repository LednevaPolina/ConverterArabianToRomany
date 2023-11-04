using ConverterArabianToRomany.Models;
using ConverterArabianToRomany.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConverterArabianToRomany.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Convert(int number)
        {
            try
            {
                ConvertService convertService = new ConvertService();
                string result=
                (string)(TempData["Result"] = convertService.ConvertToRoman(number).ToString());
                return View();
            }
            catch (Exception ex)
            {
                return Content($"Error:{ex.Message}.Insert value between 1 and 3999");
            }                    
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}