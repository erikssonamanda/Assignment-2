using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OAuth2Fb.Models;

namespace OAuth2Fb.Controllers
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
            var emailAddress = User.Identity.Name;

            if (User.Identity.IsAuthenticated)
            {
                var dateOfBirth = User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth)?.Value;
                string fbPicture = User.FindFirst(c => c.Type == "urn:facebook:picture")?.Value;
                System.Diagnostics.Debug.WriteLine("Är autentiserad");
            }
            return View();
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
