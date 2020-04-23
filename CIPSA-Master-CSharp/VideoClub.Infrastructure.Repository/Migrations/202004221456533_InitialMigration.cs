namespace VideoClub.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AccreditationType = c.Int(nullable: false),
                        Accreditation = c.String(nullable: false),
                        PhoneContact = c.String(nullable: false),
                        PhoneAux = c.String(),
                        Email = c.String(),
                        SubscriptionDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        RentalQuantity = c.Int(nullable: false),
                        IsVip = c.Boolean(nullable: false),
                        Discount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 128),
                        NumberDisc = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Time(precision: 7),
                        ProductionYear = c.Int(),
                        BuyYear = c.Int(),
                        Platform = c.Int(),
                        ProductDtoType = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Id, t.Title });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Clients");
        }
    }
}
