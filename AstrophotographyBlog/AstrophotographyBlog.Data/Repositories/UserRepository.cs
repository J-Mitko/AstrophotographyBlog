using AstrophotographyBlog.Data.Models.Users;
using AstrophotographyBlog.Data.Repositories.Contracts;

namespace AstrophotographyBlog.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MsSqlDbContext context) 
            : base(context)
        {
        }
    }
}
