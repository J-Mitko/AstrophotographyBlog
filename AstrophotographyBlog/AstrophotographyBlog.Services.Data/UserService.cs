using AstrophotographyBlog.Services.Data.Contracts;
using System;
using System.Linq;
using AstrophotographyBlog.Data.Models.Users;
using AstrophotographyBlog.Data.Repositories.Contracts;
using AstrophotographyBlog.Data;

namespace AstrophotographyBlog.Services.Data
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly ISaveContext saveContext;

        public UserService(IUserRepository userRepository, IPostRepository postRepository, ISaveContext saveContext)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.saveContext = saveContext;
        }

        public IQueryable<User> GetAll()
        {
            return userRepository.All;
        }

        public User GetById(Guid id)
        {
            return userRepository.Get(id);
        }
    }
}
