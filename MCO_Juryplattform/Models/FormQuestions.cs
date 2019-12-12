namespace MCO_Juryplattform
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormQuestions
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Question { get; set; }
    }
}
