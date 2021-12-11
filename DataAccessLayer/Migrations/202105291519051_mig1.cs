namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            AddColumn("dbo.Contents", "Writer_WriterID", c => c.Int());
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int());
            CreateIndex("dbo.Contents", "HeadingID");
            CreateIndex("dbo.Contents", "Writer_WriterID");
            AddForeignKey("dbo.Contents", "Writer_WriterID", "dbo.Writers", "WriterID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Contents", "Writer_WriterID", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "Writer_WriterID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            AlterColumn("dbo.Contents", "HeadingID", c => c.Int(nullable: false));
            DropColumn("dbo.Contents", "Writer_WriterID");
            CreateIndex("dbo.Contents", "HeadingID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID", cascadeDelete: true);
        }
    }
}
