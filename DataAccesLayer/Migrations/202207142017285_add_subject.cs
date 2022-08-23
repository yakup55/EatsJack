namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_subject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactSubject", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactSubject");
        }
    }
}
