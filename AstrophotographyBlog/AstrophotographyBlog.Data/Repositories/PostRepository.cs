using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Data.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrophotographyBlog.Data
{
    public class PostRepository : EfRepository<Post>, IPostRepository
    {
        public PostRepository(MsSqlDbContext context) 
            : base(context)
        {
        }
    }
}
