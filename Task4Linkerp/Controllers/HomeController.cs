using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Task4Linkerp.Models;

namespace Task4Linkerp.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

    }


}
