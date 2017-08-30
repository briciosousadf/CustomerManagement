namespace WebCustumerManagerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustFKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", "dbo.EntityOccupationGroups");
            DropIndex("dbo.EntityCustomers", new[] { "OccupationGroup_OccupationGroupId" });
            AlterColumn("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId");
            AddForeignKey("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", "dbo.EntityOccupationGroups", "OccupationGroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", "dbo.EntityOccupationGroups");
            DropIndex("dbo.EntityCustomers", new[] { "OccupationGroup_OccupationGroupId" });
            AlterColumn("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", c => c.Int());
            CreateIndex("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId");
            AddForeignKey("dbo.EntityCustomers", "OccupationGroup_OccupationGroupId", "dbo.EntityOccupationGroups", "OccupationGroupId");
        }
    }
}
