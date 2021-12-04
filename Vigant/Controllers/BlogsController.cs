using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vigant.Models;
using Vigant.Services.Interfaces;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogService _service;
        private IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public BlogsController(IBlogService service, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this._service = service;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            var blogs = _service.GetBlogs().Result.OrderByDescending(x => x.UploadDate).ToList();
            var blogsView = new List<BlogViewModel>();
            foreach (var b in blogs)
            {
                BlogViewModel blog = this._mapper.Map<BlogViewModel>(b);
                blogsView.Add(blog);
            }
            return View(blogsView);
        }

        public IActionResult Blog(string id)
        {
            var blog = _service.GetBlog(id).Result;
            var comments = new List<CommentViewModel>();
            blog.Comments ??= new List<Comment>();
            foreach (var comment in blog.Comments)
            {
                CommentViewModel c = _mapper.Map<CommentViewModel>(comment);
                comments.Add(c);
            }
            BlogViewModel blogView = _mapper.Map<BlogViewModel>(blog);
            blogView.Comments = comments;
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
            Blog blog = this._mapper.Map<Blog>(input);
            blog.Creator = this._userManager.GetUserAsync(User).Result;
            _service.AddBlog(blog);
            return RedirectToAction("Index");
        }
    }
}
