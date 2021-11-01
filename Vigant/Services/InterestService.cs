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
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<List<Interest>> GetInterests() => this._context.Interests.ToListAsync();

        public Task<Interest> ShowInterest(string interestId) => this._context.Interests.SingleOrDefaultAsync(x => x.Id == interestId);

        public async Task JoinInterest(ApplicationUser user, string interestId)
        {
            this._context.Interests.SingleOrDefault(x => x.Id == interestId).Participants.Add(user);
            await this._context.SaveChangesAsync();
        }

        public async Task LeaveInterest(ApplicationUser user, string interestId)
        {
            this._context.Interests.SingleOrDefault(x => x.Id == interestId).Participants.Remove(user);
            await this._context.SaveChangesAsync();
        }

        public async Task CreateInterest(Interest interest)
        {
            this._context.Interests.Add(interest);
            await this._context.SaveChangesAsync();
        }
    }
}
