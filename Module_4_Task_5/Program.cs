using System;
using System.Threading.Tasks;

namespace Module_4_Task_5
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await using (var context = new SampleContextFactory().CreateDbContext(args))
            {
                await new DataQueries(context).UpdateTwoEntities();
            }

            Console.ReadKey();
        }
    }
}
