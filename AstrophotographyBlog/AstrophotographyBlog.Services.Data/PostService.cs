using AstrophotographyBlog.Services.Data.Contracts;
using System;
using System.Linq;
using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Data.Repositories.Contracts;
using AstrophotographyBlog.Data;
using System.Collections.Generic;

namespace AstrophotographyBlog.Services.Data
{
    public class PostService : IPostService
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly ISaveContext saveContext;

        public PostService(IUserRepository userRepository, IPostRepository postRepository, ISaveContext saveContext)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.saveContext = saveContext;
        }

        public void CreatePost(string title, string imageTarget,
            string imageUrl, string imageInfo, string location, DateTime time, string authorId)
        {
            var newPost = new Post()
            {
                Title = title,
                ImageTarget = imageTarget,
                ImageUrl = imageUrl,
                ImageInfo = imageInfo,
                Location = location,
                Time = time,
                AuthorId = authorId

            };

            this.postRepository.Add(newPost);
            this.saveContext.Commit();
        }

        public ICollection<Post> GetAll()
        {
            return this.postRepository.All.ToList();
        }

        public Post GetById(Guid id)
        {
            return this.postRepository.Get(id);
        }

    }
}
