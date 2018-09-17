namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphotoemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Photo");
        }
    }
}
