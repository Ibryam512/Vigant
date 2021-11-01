using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vigant.Models;
using Vigant.Services.Interfaces;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class InterestController : Controller
    {
        private IInterestService _service;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;

        public InterestController(IInterestService service, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            var interests = this._service.GetInterests().Result;
            var interestsView = new List<InterestViewModel>();
            foreach (var i in interests)
            {
                var interest = _mapper.Map<InterestViewModel>(i);
                interestsView.Add(interest);
            }
            return View(interestsView);
        }

        [Route("Interest/{id}")]
        public IActionResult Interest(string id)
        {
            var interest = this._service.ShowInterest(id).Result;
            var interestView = _mapper.Map<InterestViewModel>(interest);
            return View(interestView);
        }

        [Route("Interest/Add")]
        public IActionResult AddInterest() //администратори
        {
            return View();
        }

        [HttpPost("Interest/Add")]
        public IActionResult Add(InterestInputViewModel input)
        {
            var interest = this._mapper.Map<Interest>(input);
            this._service.CreateInterest(interest);
            return RedirectToAction("Index");
        }

        [HttpPost("Interest/Join/{id}")]
        public IActionResult Join(string id)
        {
            var user = this._userManager.GetUserAsync(User).Result;
            this._service.JoinInterest(user, id);
            return RedirectToAction(id);
        }
    }
}
