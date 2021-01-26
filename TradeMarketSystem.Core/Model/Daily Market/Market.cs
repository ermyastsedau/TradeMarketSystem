using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarketSystem.Core.Model.Daily_Market
{
  public   class Market
    {
        public int MarketId { get; set; }

        public String Name { get; set; }


        public String Code { get; set; }

        public int? WeredaId { get; set; }

        public int? SubcityId { get; set; }

        public String Description { get; set; }
        public String Remark { get; set; }


    }
}
