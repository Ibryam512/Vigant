using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vigant.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ApplicationUser> Friends { get; set; }
        public List<Link> Links { get; set; }
        public ApplicationRole Role { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
