namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDBv2createImageM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {            
            DropTable("dbo.ImageMs");
        }
    }
}
