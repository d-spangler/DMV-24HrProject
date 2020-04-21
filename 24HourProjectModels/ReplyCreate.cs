using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class ReplyCreate
    {
        [Required]
        [Display(Name = "Your Reply")]
        [MaxLength(1000, ErrorMessage = "Reply is too long.")]
        [MinLength(10, ErrorMessage = "Reply must contain content.")]
        public string Content { get; set; }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId)]
        public virtual Comment comment { get; set; }
    }
}
