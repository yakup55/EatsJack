namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_iliskil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Eats_EatsId", "dbo.Eats");
            DropIndex("dbo.Comments", new[] { "Eats_EatsId" });
            RenameColumn(table: "dbo.Comments", name: "Eats_EatsId", newName: "EatsId");
            AlterColumn("dbo.Comments", "EatsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "EatsId");
            AddForeignKey("dbo.Comments", "EatsId", "dbo.Eats", "EatsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "EatsId", "dbo.Eats");
            DropIndex("dbo.Comments", new[] { "EatsId" });
            AlterColumn("dbo.Comments", "EatsId", c => c.Int());
            RenameColumn(table: "dbo.Comments", name: "EatsId", newName: "Eats_EatsId");
            CreateIndex("dbo.Comments", "Eats_EatsId");
            AddForeignKey("dbo.Comments", "Eats_EatsId", "dbo.Eats", "EatsId");
        }
    }
}
