namespace CollegeDBEF_001.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Number = c.Int(nullable: false),
                        Department = c.String(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        ScoreID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Date_Assigned = c.DateTime(nullable: false),
                        Date_Due = c.DateTime(nullable: false),
                        Date_Submitted = c.DateTime(nullable: false),
                        Points_Earned = c.Int(nullable: false),
                        Points_Possible = c.Int(nullable: false),
                        Score_ID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ScoreID)
                .ForeignKey("dbo.Classes", t => t.Score_ID_ID)
                .Index(t => t.Score_ID_ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Long(nullable: false),
                        Clubs = c.String(),
                        Scholarships = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "Student_ID", "dbo.Students");
            DropForeignKey("dbo.Scores", "Score_ID_ID", "dbo.Classes");
            DropIndex("dbo.Scores", new[] { "Score_ID_ID" });
            DropIndex("dbo.Classes", new[] { "Student_ID" });
            DropTable("dbo.Students");
            DropTable("dbo.Scores");
            DropTable("dbo.Classes");
        }
    }
}
