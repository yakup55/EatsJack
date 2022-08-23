namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_mighata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Eats", "EatsName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Eats", "EatsImage", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Eats", "EatsSpecification", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Eats", "EatsIngredients", c => c.String(nullable: false, maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Eats", "EatsIngredients", c => c.String(maxLength: 400));
            AlterColumn("dbo.Eats", "EatsSpecification", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Eats", "EatsImage", c => c.String(maxLength: 300));
            AlterColumn("dbo.Eats", "EatsName", c => c.String(maxLength: 50));
        }
    }
}
