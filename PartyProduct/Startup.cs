using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyProduct.Startup))]
namespace PartyProduct
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
