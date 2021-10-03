using Microsoft.AspNetCore.Identity;
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
    public class InterestService : IInterestService
    {
        private ApplicationDbContext _context;

        public InterestService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Task<List<Interest>> GetInterests() => this._context.Interests.ToListAsync();

        public Task<Interest> ShowInterest(string interestId) => this._context.Interests.SingleAsync(x => x.Id == interestId);

        public void JoinInterest(string userId, string interestId)
        {
            var user = this._context.Users.SingleAsync(x => x.Id == userId);
            this._context.Interests.Single(x => x.Id == interestId).Participants.Add(user.Result);
            this._context.SaveChanges();
        }

        public void LeaveInterest(string userId, string interestId)
        {
            var user = this._context.Users.SingleAsync(x => x.Id == userId);
            this._context.Interests.Single(x => x.Id == interestId).Participants.Remove(user.Result);
            this._context.SaveChanges();
        }
    }
}
