using System;
using System.Collections.Generic;

namespace Vigant.ViewModels
{
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserViewModel> Friends { get; set; }
        public List<LinkViewModel> Links { get; set; }
        public RoleViewModel Role { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
