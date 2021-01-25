
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMarketSystem.Core.Model.Daily_Market;

namespace ExceedERP.DataAccess.Context
{
   public class DailyMarketEntityConfiguration
    {
        public class SubCityEntityTypeConfiguration : EntityTypeConfiguration<SubCity>
        {

            public SubCityEntityTypeConfiguration()
            {
                this.ToTable("SubCity", "DailyMarket");
                this.HasKey<int>(t => t.SubCityId);

            }
        }


 


    }
}
