namespace FinLibrary.Repo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyInfo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Rate { get; set; }

        [Column(TypeName = "money")]
        public decimal MinimumAmount { get; set; }

        [Column(TypeName = "money")]
        public decimal MaximumAmount { get; set; }

        public int MinimumDuration { get; set; }

        public int MaximumDuration { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeOfLoan { get; set; }

        [Required]
        [StringLength(50)]
        public string WebAddress { get; set; }

        public int VisitCounter { get; set; }

        public int UniqueVisit { get; set; }
    }
}
