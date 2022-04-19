namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contentstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterStatus");
            DropColumn("dbo.Contents", "ContentStatus");
        }
    }
}
