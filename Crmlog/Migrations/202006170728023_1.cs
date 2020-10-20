namespace Crmlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commissions",
                c => new
                    {
                        ComId = c.Int(nullable: false, identity: true),
                        ComName = c.String(),
                        Cafedra = c.String(),
                    })
                .PrimaryKey(t => t.ComId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        CommissionComId = c.Int(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.Commissions", t => t.CommissionComId)
                .Index(t => t.CommissionComId);
            
            CreateTable(
                "dbo.Group2",
                c => new
                    {
                        Group2Id = c.Int(nullable: false, identity: true),
                        GroupGroupId = c.Int(),
                        TeacherIdTeacher = c.Int(),
                        SubjectsSubjId = c.Int(),
                        MonthName = c.String(),
                        Groups_GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Group2Id)
                .ForeignKey("dbo.Groups", t => t.Groups_GroupId)
                .ForeignKey("dbo.Subjects", t => t.SubjectsSubjId)
                .ForeignKey("dbo.Teachers", t => t.TeacherIdTeacher)
                .Index(t => t.TeacherIdTeacher)
                .Index(t => t.SubjectsSubjId)
                .Index(t => t.Groups_GroupId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjId = c.Int(nullable: false, identity: true),
                        ShortName = c.String(),
                        SubjName = c.String(),
                    })
                .PrimaryKey(t => t.SubjId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        IdTeacher = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        SubjectsSubjId = c.Int(),
                        Commission_ComId = c.Int(),
                    })
                .PrimaryKey(t => t.IdTeacher)
                .ForeignKey("dbo.Subjects", t => t.SubjectsSubjId)
                .ForeignKey("dbo.Commissions", t => t.Commission_ComId)
                .Index(t => t.SubjectsSubjId)
                .Index(t => t.Commission_ComId);
            
            CreateTable(
                "dbo.Navantazhennyas",
                c => new
                    {
                        NavantazhId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        TeacherIdTeacher = c.Int(),
                        Month = c.String(),
                        TypeNav = c.String(),
                        QantityNav = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NavantazhId)
                .ForeignKey("dbo.Teachers", t => t.TeacherIdTeacher)
                .Index(t => t.TeacherIdTeacher);
            
            CreateTable(
                "dbo.Planoves",
                c => new
                    {
                        PlanoveId = c.Int(nullable: false, identity: true),
                        Month = c.String(),
                        TeacherIdTeacher = c.Int(),
                        PlanBudg = c.Int(nullable: false),
                        PlanContact = c.Int(nullable: false),
                        ZnattyaBudg = c.Int(nullable: false),
                        ZnattyaContact = c.Int(nullable: false),
                        PislyaZnattyaBudg = c.Int(nullable: false),
                        PislyaZnattyaContact = c.Int(nullable: false),
                        VykonanoBudg = c.Int(nullable: false),
                        VykonanoContract = c.Int(nullable: false),
                        VykonatyBudg = c.Int(nullable: false),
                        VykonatyContact = c.Int(nullable: false),
                        PerevykonatyBudg = c.Int(nullable: false),
                        PerevykonatyContract = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanoveId)
                .ForeignKey("dbo.Teachers", t => t.TeacherIdTeacher)
                .Index(t => t.TeacherIdTeacher);
            
            CreateTable(
                "dbo.Znattyas",
                c => new
                    {
                        ZnattyaId = c.Int(nullable: false, identity: true),
                        DateTimeFrom = c.DateTime(nullable: false),
                        DateTimeTill = c.DateTime(nullable: false),
                        TeacherIdTeacher = c.Int(),
                        Month = c.String(),
                        TypeZ = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZnattyaId)
                .ForeignKey("dbo.Teachers", t => t.TeacherIdTeacher)
                .Index(t => t.TeacherIdTeacher);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Commission_ComId", "dbo.Commissions");
            DropForeignKey("dbo.Znattyas", "TeacherIdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "SubjectsSubjId", "dbo.Subjects");
            DropForeignKey("dbo.Planoves", "TeacherIdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Navantazhennyas", "TeacherIdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Group2", "TeacherIdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.Group2", "SubjectsSubjId", "dbo.Subjects");
            DropForeignKey("dbo.Group2", "Groups_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CommissionComId", "dbo.Commissions");
            DropIndex("dbo.Znattyas", new[] { "TeacherIdTeacher" });
            DropIndex("dbo.Planoves", new[] { "TeacherIdTeacher" });
            DropIndex("dbo.Navantazhennyas", new[] { "TeacherIdTeacher" });
            DropIndex("dbo.Teachers", new[] { "Commission_ComId" });
            DropIndex("dbo.Teachers", new[] { "SubjectsSubjId" });
            DropIndex("dbo.Group2", new[] { "Groups_GroupId" });
            DropIndex("dbo.Group2", new[] { "SubjectsSubjId" });
            DropIndex("dbo.Group2", new[] { "TeacherIdTeacher" });
            DropIndex("dbo.Groups", new[] { "CommissionComId" });
            DropTable("dbo.Znattyas");
            DropTable("dbo.Planoves");
            DropTable("dbo.Navantazhennyas");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Group2");
            DropTable("dbo.Groups");
            DropTable("dbo.Commissions");
        }
    }
}
