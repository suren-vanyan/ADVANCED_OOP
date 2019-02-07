using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationMVC.Models
{
    public class ApplicationMVCContext : DbContext
    {
        public ApplicationMVCContext (DbContextOptions<ApplicationMVCContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationMVC.Models.Company> Company { get; set; }
    }
}
