namespace GeyikLounge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migOne : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.MenuCategories",
                c => new
                    {
                        MenuCategoryId = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Title = c.String(),
                        IconUrl = c.String(),
                    })
                .PrimaryKey(t => t.MenuCategoryId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(),
                        MenuCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.MenuCategories", t => t.MenuCategoryId, cascadeDelete: true)
                .Index(t => t.MenuCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "MenuCategoryId", "dbo.MenuCategories");
            DropIndex("dbo.Menus", new[] { "MenuCategoryId" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuCategories");
            DropTable("dbo.Admins");
        }
    }
}
