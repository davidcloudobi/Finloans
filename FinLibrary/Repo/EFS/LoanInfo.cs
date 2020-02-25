namespace FinLibrary.Repo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LoanInfo
    {
        public int Id { get; set; }

        [Required]
        public string LoanType { get; set; }

        public decimal Amount { get; set; }

        public double Duration { get; set; }

        public decimal AmountWithInterest { get; set; }
    }
}
