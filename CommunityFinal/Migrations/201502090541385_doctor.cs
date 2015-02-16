namespace CommunityFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorEntries",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Degree = c.String(nullable: false, maxLength: 50),
                        Specialization = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DoctorEntries");
        }
    }
}
