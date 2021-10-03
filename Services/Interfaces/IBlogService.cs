using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Models;

namespace Vigant.Services.Interfaces
{
    interface IBlogService
    {
        Task<List<Blog>> GetBlogs();
        Task<Blog> GetBlog(string blogId);
        void AddBlog(Blog blog);
        void AddComment(string blogId, Comment comment);

    }
}
