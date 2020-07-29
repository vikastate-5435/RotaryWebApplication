namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketItemDetails", "ProductName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasketItemDetails", "ProductName", c => c.String(maxLength: 100));
        }
    }
}
