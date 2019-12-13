namespace MCO_Juryplattform
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JuryModel : DbContext
    {
        public JuryModel()
            : base("name=JuryModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<FormQuestions> FormQuestions { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<VoteCheck> VoteCheck { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormQuestions>()
                .Property(e => e.Category)
                .IsUnicode(false);
        }
    }
}
