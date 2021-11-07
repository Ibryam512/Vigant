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

        public UserService(ApplicationDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<ApplicationUser> FindUser(string userName) => this._context.Users.SingleOrDefaultAsync(x => x.UserName == userName);

        public Task<List<ApplicationUser>> GetUsers() => this._context.Users.ToListAsync();

        public List<ApplicationUser> ShowFriends(string userId) => GetUsers().Result.SingleOrDefault(x => x.Id == userId).Friends ?? new List<ApplicationUser>();

        public List<ApplicationUser> ShowParticipants(string interestId) => this._context.Interests.SingleOrDefault(x => x.Id == interestId).Participants ?? new List<ApplicationUser>(); //TODO: Move the method in the InterestService class
    }
}
