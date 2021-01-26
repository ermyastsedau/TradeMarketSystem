using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarketSystem.Core.Model.Daily_Market
{
    public class Commodity
    {

        public int CommodityId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int? UnitOfMeasurementId { get; set; }

        public int? CommodityCategoryId { get; set; }
    }
}
