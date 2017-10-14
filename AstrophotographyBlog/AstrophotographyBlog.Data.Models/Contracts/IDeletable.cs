using System;

namespace AstrophotographyBlog.Data.Models
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}