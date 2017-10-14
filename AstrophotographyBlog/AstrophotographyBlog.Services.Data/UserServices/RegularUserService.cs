using AstrophotographyBlog.Services.Data.Contracts;
using System;
using System.Linq;
using AstrophotographyBlog.Data.Models.Users;
using AstrophotographyBlog.Data.Contracts;

namespace AstrophotographyBlog.Services.Data.UserServices
{
    public class RegularUserService : IRegularUserService
    {
        //private readonly IEfRepository<RegularUser> regularUsers;

        public IQueryable<RegularUser> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
