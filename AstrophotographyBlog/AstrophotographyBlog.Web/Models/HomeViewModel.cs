using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstrophotographyBlog.Web.Models
{
    public class HomeViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}