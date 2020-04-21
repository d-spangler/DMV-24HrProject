using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectModels
{
    public class LikeCreate
    {
        [Key]
        public Guid OwnerId { get; set; }

        public bool LikedPost { get; set; }

        public string Liker { get; set; }
    }
}
