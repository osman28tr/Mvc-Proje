namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteWriterContentStateColumnInTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "WriterHeadingState");
            DropColumn("dbo.Contents", "WriterContentState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "WriterContentState", c => c.Boolean(nullable: false));
            AddColumn("dbo.Headings", "WriterHeadingState", c => c.Boolean(nullable: false));
        }
    }
}
