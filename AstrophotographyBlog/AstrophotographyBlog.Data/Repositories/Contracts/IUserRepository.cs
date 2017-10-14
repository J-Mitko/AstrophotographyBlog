using AstrophotographyBlog.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrophotographyBlog.Data.Repositories.Contracts
{
    public interface IUserRepository : IEfRepository<User>
    {
    }
}
