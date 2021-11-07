using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Vigant.Data;
using Vigant.Models;
using Vigant.Services;

namespace Vigant.Tests
{
    public class UserServiceTests
    {
        private ApplicationDbContext _Context;
        private UserService _UserService;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("Vigant");
            _Context = new ApplicationDbContext(optionsBuilder.Options);
            _UserService = new UserService(_Context);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(_UserService, Is.TypeOf<UserService>());
            Assert.IsNotNull(_UserService);
        }

        [Test]
        public void ThrowArgumentNullExceptionWhenContextIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Test]
        public void FindUserTest()
        {
            string userName = "root";
            var result = _UserService.FindUser(userName).Result;

            if (result == null)
            {
                Assert.IsNull(result);
            }
            else
            {
                Assert.IsInstanceOf<ApplicationUser>(result);
                Assert.IsNotNull(result);
                Assert.That(result, Is.TypeOf<ApplicationUser>());
            }
        }

        [Test]
        public void GetUsersTest()
        {
            var result = _UserService.GetUsers().Result;

            Assert.IsInstanceOf<List<ApplicationUser>>(result);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<List<ApplicationUser>>());
        }

        [Test]
        public void ShowFriendsTest()
        {
            string userId = "1";
            var result = _UserService.ShowFriends(userId);

            Assert.IsInstanceOf<List<ApplicationUser>>(result);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<List<ApplicationUser>>());
        }
    }
}