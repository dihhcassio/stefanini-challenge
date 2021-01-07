using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Initializate
{
    public class StefaniniInitializate : CreateDatabaseIfNotExists<StefaniniDataContext>
    {
        protected override void Seed(StefaniniDataContext context)
        {
            var datasetUser = context.Set<User>();
            var datasetSeller = context.Set<Seller>();
            var datasetCustomer = context.Set<Customer>();
            var datasetPurchase = context.Set<Purchase>();

            datasetUser.Add(new User() { Id = 1, Email = "admin@app.com", Password = "admin@123".EncryptMD5(), Role = Domain.Enums.EUserRole.Administrator, CreatedAt = DateTime.Now });
            var user2 = new User() { Id = 2, Email = "seller1@app.com", Password = "seller@1".EncryptMD5(), Role = Domain.Enums.EUserRole.Seller, CreatedAt = DateTime.Now };
            var user3 = new User() { Id = 3, Email = "seller2@app.com", Password = "seller@2".EncryptMD5(), Role = Domain.Enums.EUserRole.Seller, CreatedAt = DateTime.Now };

            var seller1 = new Seller()
            {
                CreatedAt = DateTime.Now,
                Name = "Seller 1",
                User = user2,
                UserId = user2.Id,
                Id = 1
            };

            var seller2 = new Seller()
            {
                CreatedAt = DateTime.Now,
                Name = "Seller 2",
                User = user3,
                UserId = user3.Id,
                Id = 2
            };

            //datasetSeller.Add(seller1);
            //datasetSeller.Add(seller2);


            for (int i = 1; i <= 20; i++)
            {
                var customer = new Customer()
                {
                    Id = i,
                    CreatedAt = DateTime.Now,
                    City = "City " + i,
                    Classification = i % 2 == 0 ? Domain.Enums.ECustomerClassification.Regular : Domain.Enums.ECustomerClassification.Sporadic,
                    Gender = i % 2 == 0 ? Domain.Enums.ECustumerGender.Male : Domain.Enums.ECustumerGender.Female,
                    Name = "Name " + i,
                    Phone = "Phone " + i,
                    Region = "Region " + i,
                    Seller = i % 2 == 0 ? seller1 : seller2,
                    SellerId = i % 2 == 0 ? seller1.Id : seller2.Id,
                    Removed = false
                };

               // datasetCustomer.Add(customer);

                for (int j = 1; j <= 5; j++)
                {
                    datasetPurchase.Add(new Purchase()
                    {
                        Date = DateTime.Now.AddDays(-1 * (j + i)),
                        CreatedAt = DateTime.Now,
                        Id = j + (5 * (j - 1)),
                        Value = j + (5 * (j - 1)) * 10.99f,
                        CustomerId = customer.Id,
                        SellerId = customer.Seller.Id,
                        Customer = customer,
                        Seller = customer.Seller,
                        Removed = false
                    });
                }
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
