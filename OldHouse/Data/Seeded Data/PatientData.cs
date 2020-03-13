using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldHouse.Data.Seeded_Data
{
    public class PatientData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Patients.Any())
                {
                    return;   // DB has been seeded
                }

                context.Patients.AddRange(

                    new Patient
                    {
                        FirstName = "Hassan",
                        LastName = "Assaad",
                        BloodType = "B+",
                        Birthdate = new DateTime(1999,1,28)
                    },

                        new Patient
                        {
                            FirstName = "Mohammad",
                            LastName = "Hijazi",
                            BloodType = "O+",
                            Gender = "Male",
                            Birthdate = new DateTime(1998, 3, 18)
                        },

                          new Patient
                          {
                              FirstName = "Hadi",
                              LastName = "Saleh",
                              BloodType = "A+",
                              Gender = "Male",
                              Birthdate = new DateTime(1998, 5, 15)
                          },
                          new Patient
                          {
                              FirstName = "Mortada",
                              LastName = "Ghanem",
                              Gender = "Male",
                              Birthdate = new DateTime(1997, 10, 30),
                              BloodType = "O+"
                          }
                );
                context.SaveChanges();
            }
        }
    }
}
