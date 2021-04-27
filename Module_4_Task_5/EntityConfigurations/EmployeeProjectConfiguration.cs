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
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject");
            builder.Property(employeeProject => employeeProject.Id).HasColumnName("EmployeeProjectId");
            builder.Property(employeeProject => employeeProject.Rate).IsRequired().HasColumnType("money");
            builder.Property(employeeProject => employeeProject.StartedDate).IsRequired().HasColumnType("datetime2(7)");

            builder.HasOne(employeeProject => employeeProject.Employee)
                .WithMany(employee => employee.EmployeeProject)
                .HasForeignKey(employeeProject => employeeProject.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(employeeProject => employeeProject.Project)
                .WithMany(project => project.EmployeeProject)
                .HasForeignKey(employeeProject => employeeProject.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
