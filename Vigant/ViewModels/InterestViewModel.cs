using System.Collections.Generic;

namespace Vigant.ViewModels
{
    public class InterestViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserViewModel> Participants { get; set; }
    }
}
