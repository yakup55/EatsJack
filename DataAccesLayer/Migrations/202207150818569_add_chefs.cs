namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_chefs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eats", "Chefssid", c => c.Int(nullable: false));
            AddColumn("dbo.Eats", "Chefs_ChefsId", c => c.Int());
            AddColumn("dbo.Chefs", "ChefsStatus", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Eats", "Chefs_ChefsId");
            AddForeignKey("dbo.Eats", "Chefs_ChefsId", "dbo.Chefs", "ChefsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eats", "Chefs_ChefsId", "dbo.Chefs");
            DropIndex("dbo.Eats", new[] { "Chefs_ChefsId" });
            DropColumn("dbo.Chefs", "ChefsStatus");
            DropColumn("dbo.Eats", "Chefs_ChefsId");
            DropColumn("dbo.Eats", "Chefssid");
        }
    }
}
