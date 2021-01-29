

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TradeMarketSystem.Core.Model.Common;
using TradeMarketSystem.Core.Model.Daily_Market;

namespace TradeMarketSystem.DataAccess.Context
{
    public class TradeDbContext : DbContext
    {
        public TradeDbContext()
            : base("TradeDbContext")
        {
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Configure default schema
            //  modelBuilder.HasDefaultSchema("EXCEED");

            // other code 
            Database.SetInitializer<TradeDbContext>(null);







          

   

            #region DailyMarket
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.SubCityEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.WeredaEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.MarketEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.UnitOfMeasurementEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.CommodityCategoryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TradeMarketSystem.DataAccess.Context.DailyMarketEntityConfiguration.CommodityEntityTypeConfiguration());

            #endregion






        }
































        #region  DailyMarket
        public DbSet<SubCity> SubCities { set; get; }
        public DbSet<Wereda> Weredas{ set; get; }
        public DbSet<Market> Markets { set; get; }
        public DbSet<UnitOfMeasurement> UnitOfMeasurements { set; get; }
        public DbSet<CommodityCategory> CommodityCategories { set; get; }
        public DbSet<Commodity> Commodities { set; get; }
        #endregion



    }
}
