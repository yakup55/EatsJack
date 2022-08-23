namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_malzeme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Eats", "EatsIngredients", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Eats", "EatsIngredients", c => c.String(nullable: false, maxLength: 400));
        }
    }
}
