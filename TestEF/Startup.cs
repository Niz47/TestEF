using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestEF.Startup))]
namespace TestEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
