namespace FinLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subscriptions", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subscriptions", "Email");
        }
    }
}
