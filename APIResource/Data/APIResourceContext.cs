using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIResource.Model;

namespace APIResource.Data
{
    public class APIResourceContext : DbContext
    {
        public APIResourceContext (DbContextOptions<APIResourceContext> options)
            : base(options)
        {
        }

        public DbSet<APIResource.Model.Movies> Movies { get; set; } = default!;
    }
}
