using AstrophotographyBlog.Data.Models;
using AstrophotographyBlog.Web.Infrastructure;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;


namespace AstrophotographyBlog.Web.Models
{
    public class PostViewModel : IMapFrom<AstrophotographyBlog.Data.Models.Post>
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string ImageTarget { get; set; }

        public string ImageUrl { get; set; }

        public string ImageInfo { get; set; }

        public string Location { get; set; }

        public string DisplayName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Time { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel> ()
                .ForMember(x => x.DisplayName, opts => opts.MapFrom(x => x.Author.UserName));
        }
    }
}