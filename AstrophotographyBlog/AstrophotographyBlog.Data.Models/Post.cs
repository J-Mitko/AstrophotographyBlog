using AstrophotographyBlog.Data.Models.Users;
using System;

namespace AstrophotographyBlog.Data.Models
{
    public class Post : DataModel
    {
        public string Title { get; set; }

        public string ImageTarget { get; set; }

        public string ImageUrl { get; set; }

        public string ImageInfo { get; set; }

        public string Location { get; set; }

        public DateTime Time { get; set; }

        public virtual MainUser Author { get; set; }
    }
}