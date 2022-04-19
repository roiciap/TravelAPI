using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace TravelAPI.Entities
{
    public class DBInit
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataBase>();
                context.Database.EnsureCreated();

                if (!context.Klienci.Any())
                {
                    context.Klienci.AddRange(new List<Klient>()
                    {
                        new Klient()
                        {
                            Imie = "Mateusz",
                            Nazwisko ="Bazior"
                        },
                         new Klient()
                        {
                            Imie = "Daniel",
                            Nazwisko ="Latas"
                        },
                        new Klient()
                        {
                            Imie = "Bartosz",
                            Nazwisko ="Lato"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
