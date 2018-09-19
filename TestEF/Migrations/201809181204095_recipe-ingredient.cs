namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipeingredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ingredient_id = c.Int(nullable: false, identity: true),
                        recipe_id = c.Int(),
                        ingredient_name = c.String(),
                        ingredient_amount = c.String(),
                    })
                .PrimaryKey(t => t.ingredient_id)
                .ForeignKey("dbo.Recipes", t => t.recipe_id)
                .Index(t => t.recipe_id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        recipe_id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        recipe_name = c.String(),
                    })
                .PrimaryKey(t => t.recipe_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "recipe_id", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "recipe_id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
