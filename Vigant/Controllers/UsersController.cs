using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;
using Vigant.Services;
using Vigant.Services.Interfaces;
using Vigant.ViewModels;


namespace Vigant.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(IUserService service, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public IActionResult Index() //администратори
        {
            var users = this._service.GetUsers().Result.Select(x => this._mapper.Map<UserViewModel>(x)).ToList();
            return View(users);
        }

        [Route("Users/{userName}")]
        public IActionResult UserDetails(string userName)
        {
            var user = this._service.FindUser(userName).Result;
            var userView = _mapper.Map<UserViewModel>(user);
            return View(userView);
        }

        [Route("Users/MyProfile")]
        public IActionResult MyProfile()
        {
            var user = this._userManager.GetUserAsync(User).Result;
            var userView = _mapper.Map<UserViewModel>(user);
            return View(userView);
        }
    }
}
