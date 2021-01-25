using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradeMarketSystem.Startup))]
namespace TradeMarketSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
