using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinLibrary.Model.EF
{
   public class VisitInfo
    {
        public int Id  { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string LoanType { get; set; }
        public bool VisitCounter { get; set; } = false;

        public bool UniqueVisit { get; set; } = false;
    }
}
