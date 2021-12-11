namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateYeteneksTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yeteneks",
                c => new
                    {
                        YetenekID = c.Int(nullable: false, identity: true),
                        YetenekName = c.String(),
                        YetenekValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YetenekID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Yeteneks");
        }
    }
}
