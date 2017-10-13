using AstrophotographyBlog.Data.Contracts.Models;
using System;

namespace AstrophotographyBlog.Data.Models
{
    public class Post : DataModel
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string ImageInfo { get; set; }

        public string Location { get; set; }

        public virtual User Author { get; set; }
    }
}