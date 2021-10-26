using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vigant.Models;
using Vigant.Services;
using Vigant.Services.Interfaces;
using Vigant.ViewModels;

namespace Vigant.Controllers
{
    public class BlogsController : Controller
    {
        private IBlogService _service;
        private IMapper _mapper;
        public BlogsController(IBlogService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
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
            var creator = blog.Creator;
            UserViewModel user = this._mapper.Map<UserViewModel>(creator);
            var comments = new List<CommentViewModel>();
            foreach (var comment in blog.Comments)
            {
                UserViewModel u = this._mapper.Map<UserViewModel>(comment.User);
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
            Blog blog = this._mapper.Map<Blog>(input);
            _service.AddBlog(blog);
            return RedirectToAction("Index");
        }
    }
}
