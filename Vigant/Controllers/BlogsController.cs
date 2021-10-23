using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Vigant.Models;
using Vigant.Services;
using Vigant.Services.Interfaces;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogService _service;
        public BlogsController(IBlogService service)
        {
            this._service = service;
        }

        public IActionResult Index()
        {
            var blogs = _service.GetBlogs().Result;
            var blogsView = new List<BlogViewModel>();
            foreach (var blog in blogs)
            {
                BlogViewModel view = new BlogViewModel
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Description = blog.Description,
                    Accessbility = blog.Accessbility
                };
                blogsView.Add(view);
            }
            return View(blogsView);
        }

        public IActionResult Blog(string id)
        {
            var blog = _service.GetBlog(id).Result;
            var creator = blog.Creator;
            UserViewModel user = new UserViewModel
            {
                UserName = creator.UserName
            };
            var comments = new List<CommentViewModel>();
            foreach (var comment in blog.Comments)
            {
                UserViewModel u = new UserViewModel
                {
                    UserName = comment.User.UserName
                };
                CommentViewModel c = new CommentViewModel 
                {
                    Text = comment.Text,
                    User = u
                };
                comments.Add(c);
            }
            BlogViewModel blogView = new BlogViewModel
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                Creator = user,
                Comments = comments
            }; 
            return View(blogView);
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
                Creator = new ApplicationUser { UserName = "Ibr"} //change it
            };
            _service.AddBlog(blog);
            return RedirectToAction("Index");
        }
    }
}
