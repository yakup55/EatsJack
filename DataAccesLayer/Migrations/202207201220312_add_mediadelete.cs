namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mediadelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChefsMedias", "Chefsid", "dbo.Chefs");
            DropIndex("dbo.ChefsMedias", new[] { "Chefsid" });
            AddColumn("dbo.Chefs", "MedidInstagram", c => c.String(maxLength: 300));
            AddColumn("dbo.Chefs", "MedidFacebook", c => c.String(maxLength: 300));
            AddColumn("dbo.Chefs", "MedidLinkedin", c => c.String(maxLength: 300));
            DropColumn("dbo.ChefsMedias", "Chefsid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChefsMedias", "Chefsid", c => c.Int(nullable: false));
            DropColumn("dbo.Chefs", "MedidLinkedin");
            DropColumn("dbo.Chefs", "MedidFacebook");
            DropColumn("dbo.Chefs", "MedidInstagram");
            CreateIndex("dbo.ChefsMedias", "Chefsid");
            AddForeignKey("dbo.ChefsMedias", "Chefsid", "dbo.Chefs", "ChefsId", cascadeDelete: true);
        }
    }
}
