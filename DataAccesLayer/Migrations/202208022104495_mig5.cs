namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eats", "Chefss_ChefsId", "dbo.Chefs");
            DropIndex("dbo.Eats", new[] { "Chefss_ChefsId" });
            RenameColumn(table: "dbo.Eats", name: "Chefss_ChefsId", newName: "chefsid");
            AlterColumn("dbo.Eats", "chefsid", c => c.Int(nullable: false));
            CreateIndex("dbo.Eats", "chefsid");
            AddForeignKey("dbo.Eats", "chefsid", "dbo.Chefs", "ChefsId", cascadeDelete: true);
            DropColumn("dbo.Eats", "Chefssiid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eats", "Chefssiid", c => c.Int(nullable: false));
            DropForeignKey("dbo.Eats", "chefsid", "dbo.Chefs");
            DropIndex("dbo.Eats", new[] { "chefsid" });
            AlterColumn("dbo.Eats", "chefsid", c => c.Int());
            RenameColumn(table: "dbo.Eats", name: "chefsid", newName: "Chefss_ChefsId");
            CreateIndex("dbo.Eats", "Chefss_ChefsId");
            AddForeignKey("dbo.Eats", "Chefss_ChefsId", "dbo.Chefs", "ChefsId");
        }
    }
}
