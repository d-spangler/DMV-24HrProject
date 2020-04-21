using _24HourProjectData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class LikeEdit
    {
        public bool Like { get; set; }

        public int LikeId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post PostId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment CommentId { get; set; }

    }
}
