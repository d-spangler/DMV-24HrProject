using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date Posted")]
        public DateTimeOffset Created { get; set; }
    }
}
