namespace FinLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.VisitInfoes");
            AlterColumn("dbo.VisitInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.VisitInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.VisitInfoes");
            AlterColumn("dbo.VisitInfoes", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.VisitInfoes", "Id");
        }
    }
}
