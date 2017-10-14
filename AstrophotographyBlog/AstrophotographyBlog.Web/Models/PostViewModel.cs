using System;
using System.ComponentModel.DataAnnotations;


namespace AstrophotographyBlog.Web.Models
{
    public class PostViewModel
    {
        public Guid ID { get; set; }

        public string ImageTarget { get; set; }

        public string ImageUrl { get; set; }

        public string ImageInfo { get; set; }

        public string Location { get; set; }

        public string DisplayName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Time { get; set; }
    }
}