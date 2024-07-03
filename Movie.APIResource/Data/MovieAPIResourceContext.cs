using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.APIResource.Model;

namespace Movie.APIResource.Data
{
    public class MovieAPIResourceContext : DbContext
    {
        public MovieAPIResourceContext (DbContextOptions<MovieAPIResourceContext> options)
            : base(options)
        {
        }

        public DbSet<Movie.APIResource.Model.Movies> Movie { get; set; } = default!;
    }
}
