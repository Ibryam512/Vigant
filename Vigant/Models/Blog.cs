using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vigant.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Accessbility { get; set; }
        public List<Comment> Comments { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
