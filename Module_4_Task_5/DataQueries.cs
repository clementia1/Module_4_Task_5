using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_Task_5
{
    public class DataQueries
    {
        private readonly ApplicationContext _context;

        public DataQueries(ApplicationContext context)
        {
            _context = context;
        }

        public async Task JoinTables()
        {
            var employees = _context.Employees.Select(p => new
            {
                Name = p.FirstName,
                Title = p.TitleId,
            });
        }
    }
}
