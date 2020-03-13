using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OldHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Data.Seeded_Data
{
    public class MachineData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Machines.Any())
                {
                    return;   // DB has been seeded
                }

                context.Machines.AddRange(

                    new Machine
                    {
                        Battery = 100,
                        Status = Status.AVAILABLE
                    },

                         new Machine
                         {
                             Battery = 90,
                             Status = Status.AVAILABLE
                         },

                           new Machine
                           {
                               Battery = 40,
                               Status = Status.OUT_OF_SERVICE
                           },
                          new Machine
                          {
                              Battery = 55,
                              Status = Status.AVAILABLE
                          }
                );
                context.SaveChanges();
            }
        }
    }
}