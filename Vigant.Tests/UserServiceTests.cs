using Moq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Vigant.Data;
using Vigant.Models;
using Vigant.Services;

namespace Vigant.Tests
{
    public class Tests
    {
        //private Mock<DbContextOptions<ApplicationDbContext>> _MockedOptions;
        private Mock<ApplicationDbContext> _MockedContext;
        private UserService _UserService;

        [SetUp]
        public void Setup()
        {
            //_MockedOptions = new Mock<DbContextOptions<ApplicationDbContext>>();
            _MockedContext = new Mock<ApplicationDbContext>();
            _UserService = new UserService(_MockedContext.Object);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(_UserService, Is.TypeOf<UserService>());
            Assert.IsNotNull(_UserService);
        }

        [Test]
        public void ThrowNullReferenceExceptionWhenContextIsNull()
        {
            _MockedContext = null;
            Assert.Throws<NullReferenceException>(() => new UserService(_MockedContext.Object));
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

            Assert.IsInstanceOf<ApplicationUser>(result);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<ApplicationUser>());
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

        [Test]
        public void ShowParticipantsTest()
        {
            string interestId = "1";
            var result = _UserService.ShowParticipants(interestId);

            Assert.IsInstanceOf<List<ApplicationUser>>(result);
            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<List<ApplicationUser>>());
        }
    }
}