using AstrophotographyBlog.Data.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrophotographyBlog.Services.Data.Contracts
{
    public interface IUserService : IService
    {
        ICollection<User> GetAll();

        User GetById(Guid id);
    }
}
