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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.Property(project => project.Id).HasColumnName("ProjectId");
            builder.Property(project => project.Name).IsRequired().HasMaxLength(50);
            builder.Property(project => project.Budget).IsRequired().HasColumnType("money");
            builder.Property(project => project.StartedDate).IsRequired().HasColumnType("datetime2(7)");

            builder.HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientId).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
