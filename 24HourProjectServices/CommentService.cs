using _24HourProjectData;
using _24HourProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _24HourProjectServices
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid id)
        {
            _userId = id;
        }

        //POST
        public bool CreateComment(CommentCreate model)
        {
            var newComment =
                new Comment()
                {
                    OwnerId = _userId,
                    Content = model.Content,
                    Created = DateTimeOffset.Now,
                    PostId = model.PostId,
                    Title = $"Re:  {model.post.Title}"
                };
            using (var db = new ApplicationDbContext())
            {
                db.Comments.Add(newComment);
                return db.SaveChanges() == 1;
            }

        }

        //GET
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Comments.Where(e => e.OwnerId == _userId).Select(e =>
                  new CommentListItem
                  {
                      CommentId = e.CommentId,
                      Title = e.Title,
                      Created = e.Created
                  });
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var c = db.Comments.Single(e => e.CommentId == id
                && e.OwnerId == _userId);
                return new CommentDetail
                {
                    CommentId = c.CommentId,
                    Title = c.Title,
                    Content = c.Content,
                    Created = c.Created,
                    Modified = c.Modified,
                    PostId = c.PostId
                };
            }
        }

        //PUT
        public bool UpdateComment(CommentEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var c = db.Comments.Single(e => e.OwnerId == _userId
                  && e.CommentId == model.CommentId);

                c.Title = model.Title;
                c.Content = model.Content;
                c.Modified = DateTimeOffset.Now;

                return db.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteComment(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var c = db.Comments.Single(e => e.OwnerId == _userId
                && e.CommentId == id);
                db.Comments.Remove(c);
                return db.SaveChanges() == 1;
            }
        }
    }
}
