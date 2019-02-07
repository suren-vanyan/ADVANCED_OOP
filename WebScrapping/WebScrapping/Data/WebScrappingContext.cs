using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebScrapping.Models
{
    public class WebScrappingContext : DbContext
    {
        public WebScrappingContext (DbContextOptions<WebScrappingContext> options)
            : base(options)
        {
        }

        public DbSet<WebScrapping.Models.Company> Company { get; set; }
    }
}
