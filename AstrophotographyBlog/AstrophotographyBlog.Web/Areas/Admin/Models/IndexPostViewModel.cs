using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AstrophotographyBlog.Web.Areas.Admin.Models
{
    public class IndexPostViewModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string ImageTarget { get; set; }

        public string ImageUrl { get; set; }

        public string ImageInfo { get; set; }

        public string Location { get; set; }

        public string DisplayUserName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Time { get; set; }
       
    }
}