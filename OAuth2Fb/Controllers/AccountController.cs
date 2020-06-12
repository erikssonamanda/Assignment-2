using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAuth2Fb.Data;

namespace OAuth2Fb.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        public object Session { get; private set; }

        [HttpGet]
        public IActionResult UserDetails()
        {
            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);
            var getAccountTask = facebookService.GetAccountAsync(FacebookSettings.AccessToken);
            var account = getAccountTask.Result;
            Console.WriteLine($" {account.Id} {account.Birthday} {account.Name} {account.FirstName} {account.LastName} {account.Email} {account.ProfilePicture}");
            return View(); 
        }
    }
}
