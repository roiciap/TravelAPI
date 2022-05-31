using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
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

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new List<Role>()
                    {
                     new Role()
                     {
                         Name ="normal"
                     },
                     new Role()
                     {
                         Name ="admin"
                     }
                    });
                    context.SaveChanges();
                }
                if (!context.Klienci.Any())
                {
                    context.Klienci.AddRange(new List<Klient>()
                    {
                        new Klient()
                        {
                            passwordHash ="sadasda",
                            RoleId=1,
                            username="admin"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Lokalizacje.Any())
                {
                    context.Lokalizacje.AddRange(new List<Lokalizacja>()
                    {
                        new Lokalizacja()
                        {
                            Kraj="Hiszpania",
                            Miasto="Madryt"
                        },
                        new Lokalizacja()
                        {
                            Kraj="Hiszpania",
                            Miasto="Barcelona"
                        },
                        new Lokalizacja()
                        {
                            Kraj="Anglia",
                            Miasto="Londyn"
                        },
                        new Lokalizacja()
                        {
                            Kraj="Francja",
                            Miasto="Marsylia"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Hotele.Any())
                {
                    context.Hotele.AddRange(new List<Hotel>()
                    {
                        new Hotel()
                        {
                            LokalizacjaId=1,
                            iloscPokoi=3,
                            ImgUri="a",
                            Nazwa="Hotel1",
                            koszt=500,
                            IloscGwiazdek=5
                        },
                        new Hotel()
                        {
                            LokalizacjaId=1,
                            iloscPokoi=3,
                            ImgUri="a",
                            Nazwa="Hotel2",
                            koszt=200,
                            IloscGwiazdek=5
                        },
                        new Hotel()
                        {
                            LokalizacjaId=2,
                            iloscPokoi=3,
                            ImgUri="a",
                            Nazwa="Hotel3",
                            koszt=500,
                            IloscGwiazdek=5
                        },
                        new Hotel()
                        {
                            LokalizacjaId=3,
                            iloscPokoi=3,
                            ImgUri="a",
                            Nazwa="Hotel4",
                            koszt=500,
                            IloscGwiazdek=5
                        },
                        new Hotel()
                        {
                            LokalizacjaId=4,
                            iloscPokoi=3,
                            ImgUri="a",
                            Nazwa="Hotel5",
                            koszt=500,
                            IloscGwiazdek=5
                        },
                    });
                    context.SaveChanges();
                }
               /*if (!context.Rezerwacje.Any())
                {
                    context.Rezerwacje.AddRange(new List<Rezerwacja>()
                    {
                        new Rezerwacja()
                        {
                            KlientId=2,
                        },
                        new Rezerwacja()
                        {
                            KlientId=2,
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Wycieczki.Any())
                {
                    context.Wycieczki.AddRange(new List<Wycieczka>()
                    {
                        new Wycieczka()
                        {
                            DateStart=DateTime.Parse("Jan 1,2015"),
                            DateEnd=DateTime.Parse("Jan 10,2015"),
                            HotelId=1,
                            RezerwacjaId=1,
                        },
                        new Wycieczka()
                        {
                            DateStart=DateTime.Parse("Jan 1,2015"),
                            DateEnd=DateTime.Parse("Jan 10,2015"),
                            HotelId=1,
                            RezerwacjaId=1,
                        },
                        new Wycieczka()
                        {
                            DateStart=DateTime.Parse("Jan 1,2015"),
                            DateEnd=DateTime.Parse("Jan 10,2015"),
                            HotelId=1,
                            RezerwacjaId=1,
                        },
                    });
                    context.SaveChanges();
                }*/

            }
        }
    }
}
