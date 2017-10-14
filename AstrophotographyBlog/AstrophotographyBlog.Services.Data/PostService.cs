using AstrophotographyBlog.Services.Data.Contracts;
using System;
using System.Linq;
using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Data.Repositories.Contracts;
using AstrophotographyBlog.Data;

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

        public void CreatePost(Post post, string authorId)
        {
            post.AuthorId = this.userRepository.Get(authorId).Id;
            this.postRepository.Add(post);
            this.saveContext.Commit();
        }

        public IQueryable<Post> GetAll()
        {
            return this.postRepository.All;
        }

        public Post GetById(Guid id)
        {
            return this.postRepository.Get(id);
        }
    }
}
