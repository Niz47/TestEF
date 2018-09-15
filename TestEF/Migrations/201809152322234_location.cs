namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {            
            DropTable("dbo.Locations");
        }
    }
}
