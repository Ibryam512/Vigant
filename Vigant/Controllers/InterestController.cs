using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;

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
            var user1 = new ApplicationUser { UserName = "Ibr" };
            var user2 = new ApplicationUser { UserName = "Ivan" };
            var user3 = new ApplicationUser { UserName = "Katq" };
            var user4 = new ApplicationUser { UserName = "Zuza" };

            var interest = new Interest
            {
                Id = "1",
                Name = "Програмиране",
                Description = "Това е група за хора, които се занимават с програмиране",
                Participants = new List<ApplicationUser> { user1, user2, user3, user4 }
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
            return Index();
        }
    }
}
