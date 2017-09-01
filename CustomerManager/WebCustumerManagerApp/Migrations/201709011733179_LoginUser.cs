namespace WebCustumerManagerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityLoginUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntityLoginUser");
        }
    }
}
