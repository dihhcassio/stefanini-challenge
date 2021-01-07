using Stefanini_Test.Domain.Abstractions.Entities;
using System;

namespace Stefanini_Test.Domain.Entities
{
     public class Purchase : Entity
     {
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
     }
}
