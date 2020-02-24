using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinLibrary.Model.EF
{
   public class CompanyInfo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]

        [Column(TypeName = "money")]
        public decimal MinimumAmount { get; set; }
        [Required]

        [Column(TypeName = "money")]
        public decimal MaximumAmount { get; set; }
        [Required]

        public int MinimumDuration { get; set; }
        [Required]

        public int MaximumDuration { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfLoan { get; set; }

        [Required]
        [StringLength(50)]
        public string WebAddress { get; set; }
        [Required]

        public int VisitCounter { get; set; }

        [Required]
        public int UniqueVisit { get; set; }
    }
}
