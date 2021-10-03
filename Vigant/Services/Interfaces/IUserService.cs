using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vigant.Data;
using Vigant.Models;

namespace Vigant.Services.Interfaces
{
    interface IUserService
    {
        Task<ApplicationUser> FindUser(string userName);
        Task<List<ApplicationUser>> GetUsers();
        List<ApplicationUser> ShowParticipants(string interestId);
        List<ApplicationUser> ShowFriends(string userId);
    }
}
