namespace directory21.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategotyName = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        CategoryDescription = c.String(maxLength: 100, storeType: "nvarchar"),
                        ResourcesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resources", t => t.ResourcesId, cascadeDelete: true)
                .Index(t => t.ResourcesId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        ItemDescription = c.String(maxLength: 100, storeType: "nvarchar"),
                        CategoriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoriesId, cascadeDelete: true)
                .Index(t => t.CategoriesId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        ResourceDescription = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ResourcesId", "dbo.Resources");
            DropForeignKey("dbo.Items", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Items", new[] { "CategoriesId" });
            DropIndex("dbo.Categories", new[] { "ResourcesId" });
            DropTable("dbo.Resources");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
