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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(employee => employee.Id).HasColumnName("EmployeeId");
            builder.Property(employee => employee.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(employee => employee.LastName).IsRequired().HasMaxLength(50);
            builder.Property(employee => employee.HiredDate).IsRequired().HasColumnType("datetime2(7)");
            builder.Property(employee => employee.DateOfBirth).HasColumnType("date");

            builder.HasOne(employee => employee.Title)
                .WithMany(title => title.Employees)
                .HasForeignKey(employee => employee.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(employee => employee.Office)
                .WithMany(office => office.Employees)
                .HasForeignKey(employee => employee.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
