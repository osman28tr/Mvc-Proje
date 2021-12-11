namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteYeteneksTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Yeteneks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Yeteneks",
                c => new
                    {
                        YetenekID = c.Int(nullable: false, identity: true),
                        Sql = c.Byte(nullable: false),
                        JavaScript = c.Byte(nullable: false),
                        JQuery = c.Byte(nullable: false),
                        CShrap = c.Byte(nullable: false),
                        C = c.Byte(nullable: false),
                        AspNetMvc = c.Byte(nullable: false),
                        PHP = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.YetenekID);
            
        }
    }
}
