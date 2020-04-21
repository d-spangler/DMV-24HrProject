using _24HourProjectData;
using _24HourProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectServices
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid id)
        {
            _userId = id;
        }

        //POST
        public bool CreatePost(PostCreate model)
        {
            var newPost =
                new Post()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var dataBase = new ApplicationDbContext())
            {
                dataBase.Posts.Add(newPost);
                return dataBase.SaveChanges() == 1;
            }
        }
        //GET
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var db = new ApplicationDbContext())
            {
                var query =
                    db.Posts.Where(e => e.OwnerId == _userId)
                    .Select(e =>
                        new PostListItem
                        {
                            PostId = e.PostId,
                            Title = e.Title,
                            CreatedUtc = e.CreatedUtc
                        });
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var post =
                    db.Posts
                    .Single(e => e.PostId == id && e.OwnerId == _userId);
                return new PostDetail
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Content = post.Content,
                    CreatedUtc = post.CreatedUtc,
                    ModifiedUtc = post.ModifiedUtc
                };
            }
        }

        //PUT
        public bool UpdatePost(PostEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity =
                    db.Posts.Single(e => e.PostId == model.PostId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return db.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeletePost(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts.Single
                    (e => e.PostId == id && e.OwnerId == _userId);
                db.Posts.Remove(entity);
                return db.SaveChanges() == 1;
            }
        }
    }
}
