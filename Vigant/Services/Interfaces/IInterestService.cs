using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Data;
using Vigant.Models;

namespace Vigant.Services.Interfaces
{
    public interface IInterestService
    {
        Task<List<Interest>> GetInterests();
        Task<Interest> ShowInterest(string interestId);
        Task JoinInterest(ApplicationUser user, string interestId);
        Task LeaveInterest(ApplicationUser user, string interestId);
        Task CreateInterest(Interest interest);

    }
}
