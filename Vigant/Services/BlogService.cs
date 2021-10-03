using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Data;
using Vigant.Models;
using Vigant.Services.Interfaces;

namespace Vigant.Services
{
    public class BlogService : IBlogService
    {
        private ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<List<Blog>> GetBlogs() => this._context.Blogs.ToListAsync();

        public Task<Blog> GetBlog(string blogId) => this._context.Blogs.SingleAsync(x => x.Id == blogId);

        public void AddBlog(Blog blog)
        {
            this._context.Blogs.Add(blog);
            this._context.SaveChangesAsync();
        }

        public void AddComment(string blogId, Comment comment)
        {
            this._context.Blogs.Single(x => x.Id == blogId).Comments.Add(comment);
            this._context.SaveChanges();
        }
    }
}
