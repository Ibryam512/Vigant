using System.ComponentModel.DataAnnotations;

namespace Vigant.ViewModels
{
    public class BlogInputViewModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(30, ErrorMessage = "Заглавието трябва да е между 5 и 30 символа", MinimumLength = 5)]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [StringLength(2000, ErrorMessage = "Съдържанието трябва да е между 30 и 2000 символа", MinimumLength = 30)]
        [Display(Name = "Съдържание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Display(Name = "Достъпност")]
        public string Accessbility { get; set; }
    }
}
