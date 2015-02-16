namespace CommunityFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class treat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        DiseaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Treatment = c.String(),
                        Medicine = c.String(),
                    })
                .PrimaryKey(t => t.DiseaseId);
            
            CreateTable(
                "dbo.Doses",
                c => new
                    {
                        DoseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DoseId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MealId);
            
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        TreatmentId = c.Int(nullable: false),
                        Observation = c.String(),
                        Date = c.DateTime(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DiseaseId = c.Int(nullable: false),
                        MedicineId = c.Int(nullable: false),
                        DoseId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.DoctorEntries", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Doses", t => t.DoseId, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.MedicineId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.DiseaseId)
                .Index(t => t.MedicineId)
                .Index(t => t.DoseId)
                .Index(t => t.MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "MedicineId", "dbo.Medicines");
            DropForeignKey("dbo.Treatments", "MealId", "dbo.Meals");
            DropForeignKey("dbo.Treatments", "DoseId", "dbo.Doses");
            DropForeignKey("dbo.Treatments", "DoctorId", "dbo.DoctorEntries");
            DropForeignKey("dbo.Treatments", "DiseaseId", "dbo.Diseases");
            DropIndex("dbo.Treatments", new[] { "MealId" });
            DropIndex("dbo.Treatments", new[] { "DoseId" });
            DropIndex("dbo.Treatments", new[] { "MedicineId" });
            DropIndex("dbo.Treatments", new[] { "DiseaseId" });
            DropIndex("dbo.Treatments", new[] { "DoctorId" });
            DropTable("dbo.Treatments");
            DropTable("dbo.Meals");
            DropTable("dbo.Doses");
            DropTable("dbo.Diseases");
        }
    }
}
