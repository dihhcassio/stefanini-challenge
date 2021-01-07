using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Mapping
{
    public class PurchaseMap : EntityTypeConfiguration<Purchase>
    {

        public PurchaseMap() 
        {
            this.ToTable("purchases");

            this.HasKey<int>(p => p.Id); 

            this.Property(p => p.Id)
                .HasColumnName("id")
                .IsRequired();

            this.Property(p => p.Value)
                .HasColumnName("value")
                .IsRequired();

            this.Property(p => p.Date)
                .HasColumnName("date")
                .IsRequired();

            this.Property(p => p.SellerId)
                .HasColumnName("seller_id")
                .IsRequired();

            this.Property(p => p.CustomerId)
              .HasColumnName("customer_id")
              .IsRequired();

            this.HasRequired<Customer>(p => p.Customer)
                .WithMany(c => c.Purchases)
                .HasForeignKey<int>(p => p.CustomerId);

            this.HasRequired<Seller>(c => c.Seller);

            this.Property(p => p.UpdatedAt)
                    .HasColumnName("updated_at");

            this.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            this.Property(p => p.Removed)
                .HasColumnName("removed")
                .IsRequired();
        }
    }
}
