using System.ComponentModel.DataAnnotations;

namespace Vigant.ViewModels
{
    public class InterestInputViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(30, ErrorMessage = "Името трябва да е между 5 и 30 символа", MinimumLength = 5)]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(250, ErrorMessage = "Описанието трябва да е между 30 и 250 символа", MinimumLength = 30)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
