namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRecordsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        RecordID = c.Int(nullable: false, identity: true),
                        HeadingByWriterID = c.Int(nullable: false),
                        ContentByWriterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Records");
        }
    }
}
