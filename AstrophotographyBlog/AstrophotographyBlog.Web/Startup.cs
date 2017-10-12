using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AstrophotographyBlog.Web.Startup))]
namespace AstrophotographyBlog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
