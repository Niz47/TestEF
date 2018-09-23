namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class grocery_list : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.grocery_list",
                c => new
                    {
                        grocery_id = c.Int(nullable: false, identity: true),
                        grocery_item = c.String(),
                        grocery_amount = c.String(),
                    })
                .PrimaryKey(t => t.grocery_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.grocery_list");
        }
    }
}
