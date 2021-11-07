using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Vigant.Data;
using Vigant.Models;
using Vigant.Services;
using System.Threading.Tasks;

namespace Vigant.Tests
{
    class BlogServiceTests
    {
        private ApplicationDbContext _Context;
        private BlogService _BlogService;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("Vigant");
            _Context = new ApplicationDbContext(optionsBuilder.Options);
            _BlogService = new BlogService(_Context);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(_BlogService, Is.TypeOf<BlogService>());
            Assert.IsNotNull(_BlogService);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new BlogService(null));
        }

        [Test]
        public void GetBlogsTest()
        {
            var result = _BlogService.GetBlogs().Result;
            
            Assert.IsInstanceOf<List<Blog>>(result);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<List<Blog>>());
        }

        [Test]
        public void GetBlogTest()
        {
            string blogId = "1";
            var result = _BlogService.GetBlog(blogId).Result;
            if (result == null)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.IsInstanceOf<Blog>(result);
                Assert.IsNotNull(result);
                Assert.That(result, Is.TypeOf<Blog>());
            }
        }

        [Test]
        public void AddBlogTest()
        {
            var blog = new Blog
            {
                Title = "title",
                Description = "description",
                Accessbility = "everyone",
                Comments = new List<Comment>(),
                Creator = new ApplicationUser()
            };
            var result = _BlogService.AddBlog(blog);

            Assert.IsInstanceOf<Task>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddCommentTest()
        {
            var blogId = "1";
            var comment = new Comment
            {
                User = new ApplicationUser(),
                Text = "Ha ha, comment :D"
            };
            var result = _BlogService.AddComment(blogId, comment);

            Assert.IsInstanceOf<Task>(result);
            Assert.IsNotNull(result);
        }
    }
}
