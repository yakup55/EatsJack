namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Eats", name: "Chefs_ChefsId", newName: "Chefss_ChefsId");
            RenameIndex(table: "dbo.Eats", name: "IX_Chefs_ChefsId", newName: "IX_Chefss_ChefsId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Eats", name: "IX_Chefss_ChefsId", newName: "IX_Chefs_ChefsId");
            RenameColumn(table: "dbo.Eats", name: "Chefss_ChefsId", newName: "Chefs_ChefsId");
        }
    }
}
