using Stefanini_Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap() 
        {
            this.ToTable("users");

            this.HasKey<int>(u => u.Id);

            this.Property(u => u.Id)
             .HasColumnName("id")
             .IsRequired();

            this.Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired();

            this.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired();

            this.Property(u => u.Role)
                .HasColumnName("role")
                .IsRequired();

            this.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at");

            this.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnName("created_at");

            this.Property(u => u.Removed)
                .HasColumnName("removed")
                .IsRequired();
        }
    }
}
