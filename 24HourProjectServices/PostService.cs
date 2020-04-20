﻿using _24HourProjectAPI.Models;
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






    }
}
