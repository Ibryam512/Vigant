using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class InterestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Interest()
        {
            var user1 = new UserViewModel { UserName = "Ibr" };
			var user2 = new UserViewModel { UserName = "Кулегътъ" };
            var user3 = new UserViewModel { UserName = "Ivan" };
            var user4 = new UserViewModel { UserName = "Katq" };
            var user5 = new UserViewModel { UserName = "Zuza" };

            var interest = new InterestViewModel
            {
                Name = "Програмиране",
                Description = "Това е група за хора, които се занимават с програмиране",
                Participants = new List<UserViewModel> { user1, user2, user3, user4, user5 }
            };
            return View(interest);

        }

        [Route("Interest/Add")]
        public IActionResult AddInterest() //администратори
        {
            return View();
        }

        [HttpPost("Interest/Add")]
        public IActionResult Add()
        {
            return RedirectToAction("Index");
        }
    }
}
