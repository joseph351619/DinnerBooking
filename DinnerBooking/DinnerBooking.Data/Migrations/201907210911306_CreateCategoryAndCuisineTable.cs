namespace DinnerBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoryAndCuisineTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuisines", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Cuisines", new[] { "CategoryId" });
            DropTable("dbo.Cuisines");
            DropTable("dbo.Categories");
        }
    }
}
