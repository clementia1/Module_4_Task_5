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
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office");
            builder.Property(office => office.Id).HasColumnName("OfficeId");
            builder.Property(office => office.Title).IsRequired().HasMaxLength(100);
            builder.Property(office => office.Location).IsRequired().HasMaxLength(100);
        }
    }
}
