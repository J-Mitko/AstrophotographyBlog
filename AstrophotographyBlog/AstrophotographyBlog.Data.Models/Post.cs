using AstrophotographyBlog.Data.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstrophotographyBlog.Data.Models
{
    public class Post : DataModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        public string ImageTarget { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string ImageInfo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Location { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}