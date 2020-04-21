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
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService service = CreateCommentService();
            var c = service.GetComments();
            return Ok(c);
        }

        public IHttpActionResult Get(int id)
        {
            CommentService service = CreateCommentService();
            var reply = service.GetCommentById(id);
            return Ok(reply);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(comment)) return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.UpdateComment(comment)) return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(id)) return InternalServerError();
            return Ok();
        }



        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}
