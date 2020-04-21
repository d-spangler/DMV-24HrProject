﻿using _24HourProjectData;
using _24HourProjectModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace _24HourProjectServices
{
    public class LikeService
    {
        public readonly int _postId;

        public LikeService(int postId)
        {
            _postId = postId;
        }

        //Create
        public bool CreateLike(LikeCreate model)
        {
            using (var like = new ApplicationDbContext())
            {
                while (model.LikedPost.Equals(true))
                {
                    Console.WriteLine($"{model.Liker} likes this.");
                }

                return like.SaveChanges() == 1;
            }
        }


        //Return
        public IEnumerable<PostListItem> GetLikes()
        {
            using (var like = new ApplicationDbContext())
            {
                var queary =
                    like
                        .Post
                        .Where(e => e.PostId == _postId)
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


        //Update //Delete
        public bool RemoveLike(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var like =
                    ctx
                        .Post
                        .Single(e => e.PostId == postId);

                LikePost = false;

                return ctx.SaveChanges() == 1;
            }

        }

        


    }
}
