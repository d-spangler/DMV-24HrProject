using _24HourProjectAPI.Models;
using _24HourProjectData;
using _24HourProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectServices
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid id)
        {
            _userId = id;
        }

        //POST
        public bool CreateReply(ReplyCreate model)
        {
            var newReply =
                new Reply()
                {
                    OwnerId = _userId,
                    Content = model.Content,
                    Created = DateTimeOffset.Now,
                    CommentId = model.CommentId,
                    Title = $"Re:  {model.comment.Title}"
                };
            using (var db = new ApplicationDbContext())
            {
                db.Replies.Add(newReply);
                return db.SaveChanges() == 1;
            }

        }

        //GET
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Replies.Where(e => e.OwnerId == _userId).Select(e =>
                  new ReplyListItem
                  {
                      ReplyId = e.ReplyId,
                      Title = e.Title,
                      Created = e.Created
                  });
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var reply = db.Replies.Single(e => e.ReplyId == id
                && e.OwnerId == _userId);
                return new ReplyDetail
                {
                    ReplyId = reply.ReplyId,
                    Title = reply.Title,
                    Content = reply.Content,
                    Created = reply.Created,
                    Modified = reply.Modified,
                    CommentId = reply.CommentId
                };
            }
        }

        //PUT
        public bool UpdateReply(ReplyEdit model)
        {
            using (var db = new ApplicationDbContext())
            {
                var reply = db.Replies.Single(e => e.OwnerId == _userId
                  && e.ReplyId == model.ReplyId);

                reply.Title = model.Title;
                reply.Content = model.Content;
                reply.Modified = DateTimeOffset.Now;

                return db.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteReply(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var reply = db.Replies.Single(e => e.OwnerId == _userId
                && e.ReplyId == id);
                db.Replies.Remove(reply);
                return db.SaveChanges() == 1;
            }
        }
    }
}
