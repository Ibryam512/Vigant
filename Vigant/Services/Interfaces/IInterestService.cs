using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vigant.Data;
using Vigant.Models;

namespace Vigant.Services.Interfaces
{
    interface IInterestService
    {
        Task<List<Interest>> GetInterests();
        Task<Interest> ShowInterest(string interestId);
        Task JoinInterest(string userId, string interestId);
        Task LeaveInterest(string userId, string interestId);

    }
}
