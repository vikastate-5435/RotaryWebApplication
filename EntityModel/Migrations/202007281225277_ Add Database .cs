namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItemDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BasketID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(maxLength: 100),
                        SKU = c.String(maxLength: 100),
                        ApplicableFrom = c.DateTime(nullable: false),
                        ApplicableTo = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        KG = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BasketMasters", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID);
            
            CreateTable(
                "dbo.BasketMasters",
                c => new
                    {
                        BasketID = c.Int(nullable: false, identity: true),
                        BasketName = c.String(),
                        SKUID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketID);
            
            CreateTable(
                "dbo.OrderBaskets",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        BasketID = c.Int(nullable: false),
                        BasketName = c.String(maxLength: 250),
                        SKUID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderBy = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.BasketMasters", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID);
            
            CreateTable(
                "dbo.ProductMasters",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.UnitMasters",
                c => new
                    {
                        KG = c.Int(nullable: false, identity: true),
                        UnitName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.KG);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBaskets", "BasketID", "dbo.BasketMasters");
            DropForeignKey("dbo.BasketItemDetails", "BasketID", "dbo.BasketMasters");
            DropIndex("dbo.OrderBaskets", new[] { "BasketID" });
            DropIndex("dbo.BasketItemDetails", new[] { "BasketID" });
            DropTable("dbo.UnitMasters");
            DropTable("dbo.ProductMasters");
            DropTable("dbo.OrderBaskets");
            DropTable("dbo.BasketMasters");
            DropTable("dbo.BasketItemDetails");
        }
    }
}
