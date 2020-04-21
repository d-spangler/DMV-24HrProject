using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name="Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name ="Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
