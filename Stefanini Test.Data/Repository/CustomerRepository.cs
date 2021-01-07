using Stefanini_Test.Data.Abstractions.Repositories;
using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Enums;
using Stefanini_Test.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LinqKit;

namespace Stefanini_Test.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StefaniniDataContext context) : base(context) { }

        public List<Customer> Filter(string name, ECustumerGender? gender, string city, string region, ECustomerClassification? classification, int seller, DateTime? datetimeStart = null, DateTime? datetimeEnd = null)
        {
            var predicate = PredicateBuilder.New<Customer>();

            predicate.And(c => !c.Removed);

            if (!string.IsNullOrEmpty(name))
                predicate.And(c => c.Name.Equals(name.Trim()));

            if (gender != null)
                predicate.And(c => c.Gender == gender.Value);

            if (!string.IsNullOrEmpty(city))
                predicate.And(c => c.City.Equals(city.Trim()));

            if (!string.IsNullOrEmpty(region))
                predicate.And(c => c.Region.Equals(region.Trim()));

            if (classification != null)
                predicate.And(c => c.Classification == classification.Value);

            if (seller != 0)
                predicate.And(c => c.SellerId == seller);

            var list = _dbSet.Include(c => c.Purchases).Where(predicate).ToList();

            if (datetimeStart != null && datetimeEnd != null) {

                list = list.Where(c =>
                {
                    var lastPurchase = c.Purchases.OrderByDescending(p => p.Date).FirstOrDefault();
                    return lastPurchase.Date >= datetimeStart && lastPurchase.Date <= datetimeEnd;
                }).ToList();

            }

            return list;
        }

        public List<Customer> FindAll()
        {
            return _dbSet.Include(c => c.Purchases).Where(c => !c.Removed).ToList();
        }
    }
}
