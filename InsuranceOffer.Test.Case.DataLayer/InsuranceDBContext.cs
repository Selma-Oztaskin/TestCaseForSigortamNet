using InsuranceOffer.Test.Case.DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceOffer.Test.Case.DataLayer
{
    public class InsuranceDBContext : DbContext
    {
        public InsuranceDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<CustomerInsuranceOffers> CustomerInsuranceOffers { get; set; }
    }
}
