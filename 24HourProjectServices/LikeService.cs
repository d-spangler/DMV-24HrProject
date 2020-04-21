using _24HourProjectData;
using _24HourProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectServices
{
    public class LikeService
    {
        public readonly Guid _ownerId;

        public LikeService(Guid ownerId)
        {
            _ownerId = ownerId;
        }

        //Create
        /*public bool CreateLike(LikeCreate model)
        {
            if(model.LikedPost.Equals(true))
            {
                
            }

            
        }*/


        //Read
        public IEnumerable<PostListItem> GetLikes()
        {
            using (var like = new ApplicationDbContext())
            {
                var queary =
                    like
                        .Post
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                    CreatedUtc = e.CreatedUtc
                                });
                return queary.ToArray();
            }
        }


        //Update


        //Delete


    }
}
