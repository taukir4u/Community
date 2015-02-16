namespace CommunityFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ppj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreateCenters",
                c => new
                    {
                        CenterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Password = c.String(),
                        DistrictId = c.Int(nullable: false),
                        UpazilaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CenterId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Upazilas", t => t.UpazilaId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.UpazilaId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Population = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Upazilas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreateCenters", "UpazilaId", "dbo.Upazilas");
            DropForeignKey("dbo.CreateCenters", "DistrictId", "dbo.Districts");
            DropIndex("dbo.CreateCenters", new[] { "UpazilaId" });
            DropIndex("dbo.CreateCenters", new[] { "DistrictId" });
            DropTable("dbo.Upazilas");
            DropTable("dbo.Districts");
            DropTable("dbo.CreateCenters");
        }
    }
}
