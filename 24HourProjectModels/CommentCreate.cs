using _24HourProjectData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class CommentCreate
    {
        [Required]
        [Display(Name = "Your Comment")]
        [MaxLength(1000, ErrorMessage = "Comment is too long.")]
        [MinLength(10, ErrorMessage = "Comment must contain content.")]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post post { get; set; }
    }
}
