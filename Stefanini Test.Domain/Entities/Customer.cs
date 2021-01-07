using Stefanini_Test.Domain.Abstractions.Entities;
using Stefanini_Test.Domain.Enums;
using System.Collections.Generic;

namespace Stefanini_Test.Domain.Entities
{
    public class Customer : Entity
    {
        public ECustomerClassification Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public ECustumerGender Gender { get; set; }
        public string Region { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
