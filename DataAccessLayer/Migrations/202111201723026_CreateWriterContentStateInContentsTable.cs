﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateWriterContentStateInContentsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "WriterContentState", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "WriterContentState");
        }
    }
}
