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
    public class LikeCreate
    {
        [Key]
        public Guid OwnerId { get; set; }

        public bool LikedPost { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual User user { get; set; }
        
        public string liker 
        { 
            get
            {
                return user.Name;
            }
            set { }
        }
    }
}
