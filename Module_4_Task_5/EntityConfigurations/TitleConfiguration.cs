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
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title");
            builder.Property(title => title.Id).HasColumnName("TitleId");
            builder.Property(title => title.Name).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Title>()
            {
                new Title() { Id = 1, Name = "Software Engineer" },
                new Title() { Id = 2, Name = "Product Manager" },
                new Title() { Id = 3, Name = "Team Lead" }
            });
        }
    }
}
