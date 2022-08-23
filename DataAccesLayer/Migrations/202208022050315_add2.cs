namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eats", "Chefssiid", c => c.Int(nullable: false));
            DropColumn("dbo.Eats", "Chefssid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eats", "Chefssid", c => c.Int(nullable: false));
            DropColumn("dbo.Eats", "Chefssiid");
        }
    }
}
