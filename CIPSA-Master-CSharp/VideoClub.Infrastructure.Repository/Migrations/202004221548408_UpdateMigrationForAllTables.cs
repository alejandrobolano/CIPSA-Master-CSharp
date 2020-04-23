namespace VideoClub.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigrationForAllTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Rentals", new[] { "Product_Id", "Product_Title" }, "dbo.Products");
            DropIndex("dbo.Rentals", new[] { "Client_Id" });
            DropIndex("dbo.Rentals", new[] { "Product_Id", "Product_Title" });
            AlterColumn("dbo.Rentals", "Client_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Rentals", "Product_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Rentals", "Product_Title", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Rentals", "Client_Id");
            CreateIndex("dbo.Rentals", new[] { "Product_Id", "Product_Title" });
            AddForeignKey("dbo.Rentals", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", new[] { "Product_Id", "Product_Title" }, "dbo.Products", new[] { "Id", "Title" }, cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", new[] { "Product_Id", "Product_Title" }, "dbo.Products");
            DropForeignKey("dbo.Rentals", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Rentals", new[] { "Product_Id", "Product_Title" });
            DropIndex("dbo.Rentals", new[] { "Client_Id" });
            AlterColumn("dbo.Rentals", "Product_Title", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rentals", "Product_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rentals", "Client_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rentals", new[] { "Product_Id", "Product_Title" });
            CreateIndex("dbo.Rentals", "Client_Id");
            AddForeignKey("dbo.Rentals", new[] { "Product_Id", "Product_Title" }, "dbo.Products", new[] { "Id", "Title" });
            AddForeignKey("dbo.Rentals", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
