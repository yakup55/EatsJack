namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writerdelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "Eatsid", "dbo.Eats");
            DropForeignKey("dbo.Contents", "Writerid", "dbo.EatWriters");
            DropForeignKey("dbo.Eats", "EatWriter_WriterId", "dbo.EatWriters");
            DropIndex("dbo.Eats", new[] { "EatWriter_WriterId" });
            DropIndex("dbo.Contents", new[] { "Eatsid" });
            DropIndex("dbo.Contents", new[] { "Writerid" });
            DropColumn("dbo.Eats", "EatWriterid");
            DropColumn("dbo.Eats", "EatWriter_WriterId");
            DropColumn("dbo.Contents", "Eatsid");
            DropColumn("dbo.Contents", "Writerid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "Writerid", c => c.Int(nullable: false));
            AddColumn("dbo.Contents", "Eatsid", c => c.Int(nullable: false));
            AddColumn("dbo.Eats", "EatWriter_WriterId", c => c.Int());
            AddColumn("dbo.Eats", "EatWriterid", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "Writerid");
            CreateIndex("dbo.Contents", "Eatsid");
            CreateIndex("dbo.Eats", "EatWriter_WriterId");
            AddForeignKey("dbo.Eats", "EatWriter_WriterId", "dbo.EatWriters", "WriterId");
            AddForeignKey("dbo.Contents", "Writerid", "dbo.EatWriters", "WriterId", cascadeDelete: true);
            AddForeignKey("dbo.Contents", "Eatsid", "dbo.Eats", "EatsId", cascadeDelete: true);
        }
    }
}
