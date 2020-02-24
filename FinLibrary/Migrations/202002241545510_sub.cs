namespace FinLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sub : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Package = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscriptions");
        }
    }
}
