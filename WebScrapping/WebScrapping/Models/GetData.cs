using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrapping.Repository;

namespace WebScrapping.Models
{
    public class GetData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebScrappingContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebScrappingContext>>()))
            {
                // Look for any movies.
                if (context.Company.Any())
                {
                    return;   // DB has been seeded
                }

                string urlForSearchAllCompanies = @"https://staff.am/en/companies?CompaniesFilter%5BkeyWord%5D=&CompaniesFilter%5Bindustries%5D=&CompaniesFilter%5Bindustries%5D%5B%5D=2&CompaniesFilter%5Bemployees_number%5D=&CompaniesFilter%5Bsort_by%5D=&CompaniesFilter%5Bhas_job%5D=";


                context.Company.AddRange(
                   CompaniesRepository.SearchURLForAllCompanies(urlForSearchAllCompanies)
                );
                context.SaveChanges();
            }
        }
    }
}

