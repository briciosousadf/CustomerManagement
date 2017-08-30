namespace WebCustumerManagerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityCustomers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        OccupationGroup_OccupationGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.EntityOccupationGroups", t => t.OccupationGroup_OccupationGroupId)
                .Index(t => t.OccupationGroup_OccupationGroupId);
            
            CreateTable(
                "dbo.EntityOccupationGroups",
                c => new
                    {
                        OccupationGroupId = c.Int(nullable: false, identity: true),
                        OccupationGroupTitle = c.String(),
                    })
                .PrimaryKey(t => t.OccupationGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", "dbo.EntityOccupationGroups");
            DropIndex("dbo.EntityCustomers", new[] { "OccupationGroup_OccupationGroupId" });
            DropTable("dbo.EntityOccupationGroups");
            DropTable("dbo.EntityCustomers");
        }
    }
}
