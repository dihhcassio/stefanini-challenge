using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Mapping
{
    public class SellerMap : EntityTypeConfiguration<Seller>
    {
        public SellerMap()
        {
            this.ToTable("sellers");

            this.HasKey<int>(s => s.Id);

            this.Property(s => s.Id)
             .HasColumnName("id")
             .IsRequired();

            this.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired();

            this.Property(s => s.UserId)
               .HasColumnName("user_id")
               .IsRequired();

            this.HasRequired<User>(s => s.User);

            this.Property(s => s.UpdatedAt)
                .HasColumnName("updated_at");

            this.Property(s => s.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            this.Property(s => s.Removed)
                .HasColumnName("removed")
                .IsRequired();
        }
    }
}
