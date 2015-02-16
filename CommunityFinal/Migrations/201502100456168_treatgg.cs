namespace CommunityFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class treatgg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diseases", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diseases", "Description");
        }
    }
}
