using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class ReplyDetail
    {
        public int ReplyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CommentId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
    }
}
