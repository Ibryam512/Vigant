using System.Collections.Generic;
using Vigant.Models;

namespace Vigant.ViewModels
{
    public class InterestViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ApplicationUser> Participants { get; set; }
    }
}
