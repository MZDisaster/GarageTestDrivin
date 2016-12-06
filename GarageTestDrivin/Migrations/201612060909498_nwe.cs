namespace GarageTestDrivin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nwe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
            AlterColumn("dbo.Vehicles", "Color", c => c.String());
        }
    }
}
