namespace MCO_Juryplattform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ops : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FormQuestions", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FormQuestions", "Category", c => c.Binary(nullable: false, maxLength: 50));
        }
    }
}
