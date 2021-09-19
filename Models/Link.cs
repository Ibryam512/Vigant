using System.ComponentModel.DataAnnotations;

namespace Vigant.Models
{
    public class Link
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
