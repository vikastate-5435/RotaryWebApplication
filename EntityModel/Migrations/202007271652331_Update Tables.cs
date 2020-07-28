namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketItemDetails", "SKU", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BasketItemDetails", "SKU", c => c.String());
        }
    }
}
