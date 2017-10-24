namespace TheGioiCongNghe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableOrder_Details : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "ShipAddress");
        }
    }
}
