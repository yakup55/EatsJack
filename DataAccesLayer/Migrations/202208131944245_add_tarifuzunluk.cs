namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tarifuzunluk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Eats", "EatsSpecification", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Eats", "EatsSpecification", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
