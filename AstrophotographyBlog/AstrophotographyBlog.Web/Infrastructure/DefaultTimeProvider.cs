using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstrophotographyBlog.Web.Infrastructure
{
    public class DefaultTimeProvider : TimeProvider
    {
        private static readonly DefaultTimeProvider Provider = new DefaultTimeProvider();

        private DefaultTimeProvider()
        {
        }

        public static DefaultTimeProvider Instance
        {
            get { return DefaultTimeProvider.Provider; }
        }

        public override DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}