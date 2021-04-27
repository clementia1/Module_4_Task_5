using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module_4_Task_5.Entities;

namespace Module_4_Task_5
{
    public class DataQueries
    {
        private readonly ApplicationContext _context;

        public DataQueries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddEmployee()
        {
            var title = await _context.Titles.SingleOrDefaultAsync(t => t.Name == "QA Engineer");
            var office = await _context.Offices.SingleOrDefaultAsync(t => t.Title == "Main Office");
            var project = await _context.Projects.SingleOrDefaultAsync(p => p.Name == "SomeProject4");

            var newEmployee = new Employee
            {
                FirstName = "John",
                LastName = "Cena",
                HiredDate = new DateTime(2016, 10, 28),
                Title = title ?? new Title { Name = "QA Engineer" },
                Office = office ?? new Office { Title = "Main Office", Location = "Kharkiv" }
            };

            _context.Employees.Add(newEmployee);

            _context.EmployeeProjects.Add(new EmployeeProject
            {
                Rate = 50,
                StartedDate = DateTime.UtcNow,
                Employee = newEmployee,
                ProjectId = project.Id
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity()
        {
            var item = await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == "John" && e.LastName == "Cena");

            if (item != null)
            {
                _context.Employees.Remove(item);
            }

            await _context.SaveChangesAsync();
        }

        public async Task JoinThreeTables()
        {
            var tables = await _context.Employees.Select(e => new
                {
                    Name = e.FirstName,
                    Title = e.Title.Name,
                    Office = e.Office.Title.DefaultIfEmpty()
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateTwoEntities()
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.LastName == "Cena");

            if (employee != null)
            {
                employee.FirstName = "Steve";
                employee.LastName = "Austin";
            }

            var office = await _context.Offices.FirstOrDefaultAsync(o => o.Title == "Main Office");

            if (office != null)
            {
                office.Location = "Kyiv";
            }

            await _context.SaveChangesAsync();
        }

        public async Task DateDiff()
        {
            var projects = await _context.Projects.Select(p => new
                {
                    Name = p.Name,
                    Budget = p.Budget,
                    TimeElapsed = EF.Functions.DateDiffMillisecond(p.StartedDate, DateTime.UtcNow)
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task GroupEmployeesByTitle()
        {
            var employees = await _context.Employees
                .GroupBy(employee => employee.Title.Name)
                .Select(item => new
                {
                    item.Key,
                })
                .Where(j => !j.Key.Contains("a"))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
