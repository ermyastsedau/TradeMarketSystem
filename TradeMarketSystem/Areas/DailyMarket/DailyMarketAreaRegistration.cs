using System.Web.Mvc;

namespace TradeMarketSystem.Areas.DailyMarket
{
    public class DailyMarketAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DailyMarket";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DailyMarket_default",
                "DailyMarket/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}