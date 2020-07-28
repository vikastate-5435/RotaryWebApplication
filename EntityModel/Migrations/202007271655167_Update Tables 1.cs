namespace EntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables1 : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.UnitMasters");
            DropTable("dbo.ProductMasters");
        }
    }
}
