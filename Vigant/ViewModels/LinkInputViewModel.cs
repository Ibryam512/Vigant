using System.ComponentModel.DataAnnotations;

namespace Vigant.ViewModels
{
    public class LinkInputViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(15, ErrorMessage = "Името трябва да е между 5 и 15 символа", MinimumLength = 5)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Линк")]
        public string Path { get; set; }
    }
}
