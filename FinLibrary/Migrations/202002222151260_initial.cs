namespace FinLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Rate = c.Int(nullable: false),
                        MinimumAmount = c.Decimal(nullable: false, storeType: "money"),
                        MaximumAmount = c.Decimal(nullable: false, storeType: "money"),
                        MinimumDuration = c.Int(nullable: false),
                        MaximumDuration = c.Int(nullable: false),
                        TypeOfLoan = c.String(nullable: false, maxLength: 50),
                        WebAddress = c.String(nullable: false, maxLength: 50),
                        VisitCounter = c.Int(nullable: false),
                        UniqueVisit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoanInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanType = c.String(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Double(nullable: false),
                        AmountWithInterest = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoanInfoes");
            DropTable("dbo.CompanyInfoes");
        }
    }
}
