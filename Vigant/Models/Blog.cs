using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vigant.Models
{
    public class Blog
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Accessbility { get; set; }
        public List<Comment> Comments { get; set; }
        public ApplicationUser Creator { get; set; }
    }
}
