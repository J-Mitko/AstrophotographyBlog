using AstrophotographyBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrophotographyBlog.Services.Data.Contracts
{
    public interface IPostService : IService
    {
        IQueryable<Post> GetAll();

        Post GetById(Guid id);

        void CreatePost(Post post, string authorId);
    }
}
