namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_register : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registers", "RegisterMail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Registers", "RegisterPassword", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Registers", "RegisterPasswordAgain", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "RegisterPasswordAgain", c => c.String(maxLength: 50));
            AlterColumn("dbo.Registers", "RegisterPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Registers", "RegisterMail", c => c.String(maxLength: 50));
        }
    }
}
