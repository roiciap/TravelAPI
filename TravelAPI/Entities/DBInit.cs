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
             
            }
        }
    }
}
