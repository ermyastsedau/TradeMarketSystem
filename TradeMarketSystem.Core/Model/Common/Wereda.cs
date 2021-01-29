using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarketSystem.Core.Model.Common
{
  public   class Wereda
    {
        public int WeredaId { get; set; }
       
        public string  Code { get; set; }
        public string Name { get; set; }

        public int? SubcityId { get; set; }
        public string Description { get; set; }

         public string Remark { get; set; }
    }
}
