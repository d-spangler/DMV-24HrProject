using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class PostCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        [MinLength(1, ErrorMessage = "Post must have Title.")]
        [Display(Name = "Post Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Your Post")]
        [MaxLength(10000, ErrorMessage = "Post is too long.")]
        [MinLength(10, ErrorMessage = "Post must contain content.")]
        public string Content { get; set; }
    }
}
