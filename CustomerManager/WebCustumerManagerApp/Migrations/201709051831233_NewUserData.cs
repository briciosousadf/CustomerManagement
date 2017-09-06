namespace WebCustumerManagerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityLoginUsers", "VCodePassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntityLoginUsers", "VCodePassword");
        }
    }
}
