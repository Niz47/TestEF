namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class instruction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructions",
                c => new
                    {
                        instruction_id = c.Int(nullable: false, identity: true),
                        recipe_id = c.Int(),
                        instruction_detail = c.String(),
                    })
                .PrimaryKey(t => t.instruction_id)
                .ForeignKey("dbo.Recipes", t => t.recipe_id)
                .Index(t => t.recipe_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instructions", "recipe_id", "dbo.Recipes");
            DropIndex("dbo.Instructions", new[] { "recipe_id" });
            DropTable("dbo.Instructions");
        }
    }
}
