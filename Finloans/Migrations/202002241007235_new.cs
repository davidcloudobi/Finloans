namespace Finloans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "subStart");
            DropColumn("dbo.AspNetUsers", "subEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "subEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "subStart", c => c.DateTime(nullable: false));
        }
    }
}
