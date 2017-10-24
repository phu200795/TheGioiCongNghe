using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheGioiCongNghe.Startup))]
namespace TheGioiCongNghe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
