namespace VideoClub.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationForAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StartRental = c.DateTime(nullable: false),
                        FinishRental = c.DateTime(nullable: false),
                        Client_Id = c.String(maxLength: 128),
                        Product_Id = c.String(maxLength: 128),
                        Product_Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Products", t => new { t.Product_Id, t.Product_Title })
                .Index(t => t.Client_Id)
                .Index(t => new { t.Product_Id, t.Product_Title });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", new[] { "Product_Id", "Product_Title" }, "dbo.Products");
            DropForeignKey("dbo.Rentals", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Rentals", new[] { "Product_Id", "Product_Title" });
            DropIndex("dbo.Rentals", new[] { "Client_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
