using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(baitapthuchanh.Startup))]
namespace baitapthuchanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
