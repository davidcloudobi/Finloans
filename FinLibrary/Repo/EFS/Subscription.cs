namespace FinLibrary.Repo.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        public int Id { get; set; }

        public bool Status { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int Package { get; set; }

        public string Email { get; set; }
    }
}
