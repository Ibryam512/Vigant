using System.Collections.Generic;

namespace Vigant.ViewModels
{
    public class BlogViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Accessbility { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public UserViewModel Creator { get; set; }
    }
}
