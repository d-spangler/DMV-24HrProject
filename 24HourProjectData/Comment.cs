using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectData
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Comment Section")]
        [MaxLength(200, ErrorMessage = "Comment is too long, try again")]
        [MinLength(4, ErrorMessage = "Comment must have at least four characters, try again")]

        public string CommentAuthor { get; set; }
        [Required]
        [Display(Name = "UserName ")]
        [MaxLength(12, ErrorMessage = "Username too long, try less than 12 characters")]
        [MinLength(6, ErrorMessage = "Username too short, try at least 6 characters")]

        public string CommentContent { get; set; }

        
        

    }
}
