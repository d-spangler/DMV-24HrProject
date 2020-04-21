using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectData
{
    public class Like
    {
        [Required]
        public int LikedPost { get; set; }

        [ForeignKey(nameof(LikedPost))]//Should the foreign keys be under the Post similar to how ProductId was under Transaction in the General Store example?
        public virtual Post likedPost { get; set; }



        public Guid Liker { get; set; }

        [ForeignKey(nameof(Liker))]
        public virtual User liker { get; set; }
    }
}
