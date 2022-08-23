namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Eats", "EatsIngredients", c => c.String(maxLength: 400));
            AddColumn("dbo.Eats", "EatsStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "CommentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentStatus");
            DropColumn("dbo.Eats", "EatsStatus");
            DropColumn("dbo.Eats", "EatsIngredients");
        }
    }
}
