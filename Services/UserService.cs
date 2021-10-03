using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vigant.Data;
using Vigant.Models;
using Vigant.Services.Interfaces;

namespace Vigant.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public UserService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<ApplicationUser> FindUser(string userName) => this._context.Users.SingleAsync(x => x.UserName == userName);

        public Task<List<ApplicationUser>> GetUsers() => this._context.Users.ToListAsync();

        public List<ApplicationUser> ShowFriends(string userId) => GetUsers().Result.Single(x => x.Id == userId).Friends;

        public List<ApplicationUser> ShowParticipants(string interestId) => this._context.Interests.Single(x => x.Id == interestId).Participants;
    }
}
