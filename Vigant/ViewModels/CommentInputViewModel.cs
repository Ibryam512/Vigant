using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vigant.ViewModels
{
    public class CommentInputViewModel
    {
        [Display(Name = "Коментар")]
        public string Text { get; set; }
    }
}
