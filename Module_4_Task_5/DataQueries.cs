using System;
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
        }/*

        public async Task JoinTables()
        {
            var employees = _context.Employees.Select(p => new
            {
                Name = p.FirstName,
                Title = p.TitleId,
            });
        }*/

        public async Task AddEmployee()
        {
            var title = await _context.Titles.SingleOrDefaultAsync(t => t.Name == "QA Engineer");
            var office = await _context.Offices.SingleOrDefaultAsync(t => t.Title == "Main Office");

            _context.Employees.Add(new Employee
            {
                FirstName = "John",
                LastName = "Cena",
                HiredDate = new DateTime(2016, 10, 28),
                Title = title ?? new Title { Name = "QA Engineer" },
                Office = office ?? new Office { Title = "Main Office", Location = "Kharkiv" },
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity()
        {
            var item = await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == "John" && e.LastName == "Cena");
            _context.Employees.Remove(item);

            await _context.SaveChangesAsync();
        }

        public async Task JoinThreeTables()
        {
            var tables = await _context.Employees
                .Join(
                _context.Titles,
                employee => employee.TitleId,
                title => title.Id,
                (employee, title) => new
                {
                    employee,
                    Title = title.Name
                })
                .DefaultIfEmpty()
                .Join(
                _context.Offices,
                joinedTables => joinedTables.employee.OfficeId,
                office => office.Id,
                (joinedTables, office) => new
                {
                    joinedTables,
                    office
                })
                .ToListAsync();

            /*var tables = await _context.Employees.Include(e => e.Office).DefaultIfEmpty().Include(e => e.Title).ToListAsync();*/
        }

        public async Task UpdateTwoEntities()
        {
            _context.Offices.Add(new Office { Title = "Secondary Office", Location = "Dnipro" });
            _context.Projects.Add(new Project { Name = "Some Project", Budget = 200000, StartedDate = DateTime.UtcNow, ClientId = _context.Clients.SingleOrDefault(c => c.Name == "Ciklum").Id });

            await _context.SaveChangesAsync();
        }
    }
}
