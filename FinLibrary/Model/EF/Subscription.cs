using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinLibrary.Model.EF
{
  public  class Subscription
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Package { get; set; }
    }
}
