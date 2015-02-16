namespace CommunityFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pkklllll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Power = c.Double(nullable: false),
                        UnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicineId)
                .ForeignKey("dbo.Units", t => t.UnitId, cascadeDelete: true)
                .Index(t => t.UnitId);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.UnitId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicines", "UnitId", "dbo.Units");
            DropIndex("dbo.Medicines", new[] { "UnitId" });
            DropTable("dbo.Units");
            DropTable("dbo.Medicines");
        }
    }
}
