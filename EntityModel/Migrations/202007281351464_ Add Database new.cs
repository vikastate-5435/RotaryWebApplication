namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatabasenew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItemDetails", "BasketID", "dbo.BasketMasters");
            DropIndex("dbo.BasketItemDetails", new[] { "BasketID" });
            AlterColumn("dbo.BasketItemDetails", "BasketID", c => c.Int());
            CreateIndex("dbo.BasketItemDetails", "BasketID");
            AddForeignKey("dbo.BasketItemDetails", "BasketID", "dbo.BasketMasters", "BasketID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketItemDetails", "BasketID", "dbo.BasketMasters");
            DropIndex("dbo.BasketItemDetails", new[] { "BasketID" });
            AlterColumn("dbo.BasketItemDetails", "BasketID", c => c.Int(nullable: false));
            CreateIndex("dbo.BasketItemDetails", "BasketID");
            AddForeignKey("dbo.BasketItemDetails", "BasketID", "dbo.BasketMasters", "BasketID", cascadeDelete: true);
        }
    }
}
