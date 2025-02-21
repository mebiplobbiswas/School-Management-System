namespace SchoolManagementSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdmissionCosts",
                c => new
                    {
                        AdmId = c.Int(nullable: false, identity: true),
                        StudentID = c.String(),
                        AdmissionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InformationServicefee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Libraryfee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Entertainmentfee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sportsfee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Othersfee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AdmId);
            
            CreateTable(
                "dbo.AdmissionFroms",
                c => new
                    {
                        AID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClassID = c.Int(nullable: false),
                        Nationality = c.String(),
                        Religion = c.String(),
                        Address = c.String(),
                        DateofBirth = c.String(),
                        Gender = c.String(),
                        BloodGroup = c.String(),
                    })
                .PrimaryKey(t => t.AID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassID);
            
            CreateTable(
                "dbo.ClassSections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SectionID);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationID = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DesignationID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        EducationID = c.Int(nullable: false, identity: true),
                        EducationName = c.String(),
                    })
                .PrimaryKey(t => t.EducationID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        StdID = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        StudentName = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        ClassID = c.Int(nullable: false),
                        Roll = c.String(),
                        GroupID = c.Int(nullable: false),
                        SectionID = c.Int(nullable: false),
                        Gender = c.String(),
                        Image = c.String(),
                        StdUniqueId = c.String(),
                        Group = c.String(),
                        GuardianName = c.String(),
                        Guardiannumber = c.String(),
                        Email = c.String(),
                        StudentMbNum = c.String(),
                        PresentAddress = c.String(),
                        AddressPermanent = c.String(),
                        Remarks = c.String(),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StdID);
            
            CreateTable(
                "dbo.TeacherProfiles",
                c => new
                    {
                        TPID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DesignationID = c.Int(nullable: false),
                        EducationID = c.Int(nullable: false),
                        DOF = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Nationality = c.String(),
                        BloodGroup = c.String(),
                        PersentAddress = c.String(),
                        PermanentAddress = c.String(),
                        GovernmentJoiningDate = c.DateTime(nullable: false),
                        Presentjoiningdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TPID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TeacherProfiles");
            DropTable("dbo.StudentProfiles");
            DropTable("dbo.Groups");
            DropTable("dbo.Educations");
            DropTable("dbo.Designations");
            DropTable("dbo.ClassSections");
            DropTable("dbo.Classes");
            DropTable("dbo.AdmissionFroms");
            DropTable("dbo.AdmissionCosts");
        }
    }
}
