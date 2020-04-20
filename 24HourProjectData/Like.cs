using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectData
{
    public class Like
    {
        [ForeignKey(nameof(LikedPost))]
        public virtual bool LikedPost { get; set; }

        [ForeignKey(nameof(Liker))]
        public virtual string Liker { get; set; }
    }
}
