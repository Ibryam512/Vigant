using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;

namespace Vigant.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task<Blog> GetBlog(string blogId);
        Task AddBlog(Blog blog);
        Task AddComment(string blogId, Comment comment);

    }
}
