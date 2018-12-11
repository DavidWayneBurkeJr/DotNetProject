using DotNetProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                {
                if (context.APIListModels.Any())
                {
                    return;
                }

                context.APIListModels.AddRange(
                    new APIListModel
                    {
                        Id = 1,
                        APIName = "News"
                    },
                    new APIListModel
                    {
                        Id = 2,
                        APIName = "Weather"
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
