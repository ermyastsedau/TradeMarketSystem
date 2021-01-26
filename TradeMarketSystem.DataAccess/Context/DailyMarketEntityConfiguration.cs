
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMarketSystem.Core.Model.Daily_Market;

namespace TradeMarketSystem.DataAccess.Context
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
        public class WeredaEntityTypeConfiguration : EntityTypeConfiguration<Wereda>
        {

            public WeredaEntityTypeConfiguration()
            {
                this.ToTable("Wereda", "DailyMarket");
                this.HasKey<int>(t => t.WeredaId);

            }
        }

        public class MarketEntityTypeConfiguration : EntityTypeConfiguration<Market>
        {

            public MarketEntityTypeConfiguration()
            {
                this.ToTable("Market", "DailyMarket");
                this.HasKey<int>(t => t.MarketId);

            }
        }
        public class UnitOfMeasurementEntityTypeConfiguration : EntityTypeConfiguration<UnitOfMeasurement>
        {

            public UnitOfMeasurementEntityTypeConfiguration()
            {
                this.ToTable("UnitOfMeasurement", "DailyMarket");
                this.HasKey<int>(t => t.UnitOfMeasurementId);

            }
        }
        public class CommodityCategoryEntityTypeConfiguration : EntityTypeConfiguration<CommodityCategory>
        {

            public CommodityCategoryEntityTypeConfiguration()
            {
                this.ToTable("CommodityCategory", "DailyMarket");
                this.HasKey<int>(t => t.CommodityCategoryId);

            }
        }

        public class CommodityEntityTypeConfiguration : EntityTypeConfiguration<Commodity>
        {

            public CommodityEntityTypeConfiguration()
            {
                this.ToTable("Commodity", "DailyMarket");
                this.HasKey<int>(t => t.CommodityId);

            }
        }

    }
}
