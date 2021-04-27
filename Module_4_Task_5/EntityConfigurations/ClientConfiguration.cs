using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_Task_5.Entities;

namespace Module_4_Task_5.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.Property(c => c.Id).HasColumnName("ClientId");
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.CreatedDate).HasColumnType("datetime");
        }
    }
}
