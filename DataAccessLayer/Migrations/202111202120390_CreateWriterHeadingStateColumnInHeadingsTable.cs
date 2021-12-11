namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateWriterHeadingStateColumnInHeadingsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "WriterHeadingState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "WriterHeadingState");
        }
    }
}
