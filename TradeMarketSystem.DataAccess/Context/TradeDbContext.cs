

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TradeMarketSystem.Core.Model.Daily_Market;

namespace ExceedERP.DataAccess.Context
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







          

   

            #region InfoDesk
            modelBuilder.Configurations.Add(new ExceedERP.DataAccess.Context.DailyMarketEntityConfiguration.SubCityEntityTypeConfiguration());
          
            #endregion

        




        }










    

       





      

  



       

 


    


        #region  InfoDesk
        public DbSet<SubCity> SubCities { set; get; }
              #endregion



    }
}
