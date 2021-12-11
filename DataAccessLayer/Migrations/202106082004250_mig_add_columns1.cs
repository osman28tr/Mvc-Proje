namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_columns1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drafts", "DraftSenderMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Drafts", "DraftReceiverMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Drafts", "DraftMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drafts", "DraftMail", c => c.String(maxLength: 50));
            DropColumn("dbo.Drafts", "DraftReceiverMail");
            DropColumn("dbo.Drafts", "DraftSenderMail");
        }
    }
}
