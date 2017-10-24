namespace TheGioiCongNghe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProduct_category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Article_category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Parent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Article_manager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Article_Alias = c.String(),
                        Cat_Id = c.Int(nullable: false),
                        Article_Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Article_image = c.String(),
                        Status = c.Boolean(nullable: false),
                        Article_category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Article_category", t => t.Article_category_Id)
                .Index(t => t.Article_category_Id);
            
            CreateTable(
                "dbo.Product_category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Parent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product_manager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Product_Alias = c.String(),
                        Cat_Id = c.Int(nullable: false),
                        Product_image = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Product_Description = c.String(),
                        Product_Price = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Product_category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product_category", t => t.Product_category_Id)
                .Index(t => t.Product_category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_manager", "Product_category_Id", "dbo.Product_category");
            DropForeignKey("dbo.Article_manager", "Article_category_Id", "dbo.Article_category");
            DropIndex("dbo.Product_manager", new[] { "Product_category_Id" });
            DropIndex("dbo.Article_manager", new[] { "Article_category_Id" });
            DropTable("dbo.Product_manager");
            DropTable("dbo.Product_category");
            DropTable("dbo.Article_manager");
            DropTable("dbo.Article_category");
        }
    }
}
