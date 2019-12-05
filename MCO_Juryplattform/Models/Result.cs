namespace MCO_Juryplattform
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Result")]
    public partial class Result
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int QuestionId { get; set; }

        public int Grade { get; set; }
    }
}
