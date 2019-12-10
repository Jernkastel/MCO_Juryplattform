namespace MCO_Juryplattform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blergh : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VoteCheck");
            AddPrimaryKey("dbo.VoteCheck", new[] { "UserId", "CompanyId" });
            DropColumn("dbo.FormQuestions", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormQuestions", "Category", c => c.String(nullable: false, maxLength: 50));
            DropPrimaryKey("dbo.VoteCheck");
            AddPrimaryKey("dbo.VoteCheck", new[] { "UserId", "CompanyId", "IsVoted" });
        }
    }
}
