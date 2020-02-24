namespace FinLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisitInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Company = c.String(),
                        LoanType = c.String(),
                        VisitCounter = c.Boolean(nullable: false),
                        UniqueVisit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisitInfoes");
        }
    }
}
