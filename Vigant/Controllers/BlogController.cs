﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vigant.Models;
using Vigant.Services;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class BlogController : Controller
    {
        private BlogService _service;
        private UserManager<ApplicationUser> _userManager;
        public BlogController(BlogService service, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            BlogViewModel blog = new BlogViewModel
            {
                Title = "Блог 1",
                Description = "Това представлява тялото на самият блог",
                Creator = new UserViewModel { UserName = "Ibr" },
                Comments = new List<CommentViewModel>()
            }; 
            return View(blog);
        }

        [Route("Blogs/Add")]
        public IActionResult AddBlog() //администратори и премиум потребители
        {
            return View();
        }

        [HttpPost("Blogs/Add")]
        public IActionResult AddBlog(BlogInputViewModel input)
        {
            Blog blog = new Blog
            {
                Title = input.Title,
                Description = input.Description,
                Accessbility = input.Accessbility,
                Comments = new List<Comment>(),
                //TODO: Add logged user as a creator
            };
            _ = _service.AddBlog(blog);
            return RedirectToAction("Index");
        }
    }
}