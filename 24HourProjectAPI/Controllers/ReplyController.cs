using _24HourProjectModels;
using _24HourProjectServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourProjectAPI.Controllers
{
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReplyService service = CreateReplyService();
            var replies = service.GetReplies();
            return Ok(replies);
        }

        public IHttpActionResult Get(int id)
        {
            ReplyService service = CreateReplyService();
            var reply = service.GetReplyById(id);
            return Ok(reply);
        }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply)) return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.UpdateReply(reply)) return InternalServerError;
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteReply(id)) return InternalServerError;
            return Ok();
        }



        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            return service;
        }
    }
}
