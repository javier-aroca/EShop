namespace EShop.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ShoppingCartLines", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.ShoppingCartLines", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AlterColumn("dbo.OrderLines", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderLines", "Price", c => c.Single(nullable: false));
            RenameIndex(table: "dbo.ShoppingCartLines", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.ShoppingCartLines", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
