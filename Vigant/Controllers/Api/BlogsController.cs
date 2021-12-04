using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;
using Vigant.Services.Interfaces;

namespace Vigant.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = this._service.GetBlogs().Result;
            return new JsonResult(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(string id)
        {
            var blog = this._service.GetBlog(id).Result;
            return new JsonResult(blog);
        }
    }
}
