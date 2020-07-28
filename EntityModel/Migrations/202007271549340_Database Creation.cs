namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreation : DbMigration
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
                        SKU = c.String(),
                        ApplicableFrom = c.DateTime(nullable: false),
                        ApplicableTo = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        KG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BasketMasters",
                c => new
                    {
                        BasketId = c.Int(nullable: false, identity: true),
                        BasketName = c.String(),
                        SKUID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasketMasters");
            DropTable("dbo.BasketItemDetails");
        }
    }
}
