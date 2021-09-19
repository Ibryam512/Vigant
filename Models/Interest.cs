using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vigant.Models
{
    public class Interest
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ApplicationUser> Participants { get; set; }
    }
}
