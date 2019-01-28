using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GU.Data
{
    public static class  DBInitialize
    {
        public static void INIT(IServiceProvider serviceProvider) {

            var context = new GU_DB(serviceProvider.GetRequiredService<DbContextOptions<GU_DB>>());

            context.Database.EnsureCreated();
            
        }
    }
}
