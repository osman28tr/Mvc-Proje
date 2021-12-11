namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDraftStateColumnInMessagesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "DraftState");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "DraftState", c => c.Boolean(nullable: false));
        }
    }
}
