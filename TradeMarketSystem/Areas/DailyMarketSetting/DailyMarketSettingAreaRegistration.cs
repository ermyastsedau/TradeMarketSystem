using System.Web.Mvc;

namespace TradeMarketSystem.Areas.DailyMarketSetting
{
    public class DailyMarketSettingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DailyMarketSetting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DailyMarketSetting_default",
                "DailyMarketSetting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}