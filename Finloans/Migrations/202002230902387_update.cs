namespace Finloans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "subStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "subEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "subEnd");
            DropColumn("dbo.AspNetUsers", "subStart");
        }
    }
}
