using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("customers");

            this.HasKey<int>(c => c.Id);

            this.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();

            this.Property(c => c.City)
                .IsRequired()
                .HasColumnName("city");

            this.Property(c => c.Classification)
                .IsRequired()
                .HasColumnName("classification");

            this.Property(c => c.Gender)
                .IsRequired()
                .HasColumnName("gender");


            this.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            this.Property(c => c.Phone)
                .IsRequired()
                .HasColumnName("phone");

            this.Property(c => c.Region)
                .IsRequired()
                .HasColumnName("region");

            this.Property(c => c.SellerId)
               .IsRequired()
               .HasColumnName("seller_id");

            this.HasRequired<Seller>(c => c.Seller);

            this.Property(c => c.UpdatedAt)
                    .HasColumnName("updated_at");

            this.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            this.Property(c => c.Removed)
                .HasColumnName("removed")
                .IsRequired();

            this.HasMany<Purchase>(c => c.Purchases)
                .WithRequired(p => p.Customer);
        }
    }
}
