﻿using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        public async Task<IEnumerable<Post>> GetPost()
        {
            var post = Enumerable.Range(1, 0).Select(x => new Post
            {
                PostId = x,
                Descripcion = $"Descripcion {x}",
                Date = DateTime.Now,
                Image = $"http://imagen.com/{x}",
                UserId = x * 2
            });
            await Task.Delay(10);
            return post;
        }
    }
}