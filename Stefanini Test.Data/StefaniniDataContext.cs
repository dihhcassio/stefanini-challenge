using Stefanini_Test.Data.Initializate;
using Stefanini_Test.Data.Mapping;
using System.Data.Entity;

namespace Stefanini_Test.Data
{
    public class StefaniniDataContext : DbContext
    {
        public StefaniniDataContext() : base(Effort.DbConnectionFactory.CreatePersistent("1"), false)
        {
            Database.SetInitializer(new StefaniniInitializate());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SellerMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new PurchaseMap());
        }

    }
}
