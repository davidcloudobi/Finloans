namespace FinLibrary.Repo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VisitInfo
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string LoanType { get; set; }

        public bool VisitCounter { get; set; }

        public bool UniqueVisit { get; set; }
    }
}
