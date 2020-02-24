using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinLibrary.Model.EF;

namespace FinLibrary.Model.Services
{
   public class FinData:DbContext
   {
       public  DbSet<CompanyInfo> Company { get; set; }
       public  DbSet<LoanInfo> Loan { get; set; }
       public DbSet<VisitInfo> VisitInfo { get; set; }

       public DbSet<Subscription> Subscription { get; set; }

    }
}
 