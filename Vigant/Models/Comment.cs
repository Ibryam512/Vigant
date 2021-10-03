using System.ComponentModel.DataAnnotations;

namespace Vigant.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
        public string Text { get; set; }
    }
}
