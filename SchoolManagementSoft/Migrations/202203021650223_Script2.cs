namespace SchoolManagementSoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Script2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BrID = c.Int(nullable: false, identity: true),
                        BranchName = c.String(),
                        BranchCode = c.String(),
                    })
                .PrimaryKey(t => t.BrID);
            
            CreateTable(
                "dbo.Occupations",
                c => new
                    {
                        OPID = c.Int(nullable: false, identity: true),
                        OccupationName = c.String(),
                    })
                .PrimaryKey(t => t.OPID);
            
            CreateTable(
                "dbo.Religions",
                c => new
                    {
                        RID = c.Int(nullable: false, identity: true),
                        ReligionName = c.String(),
                    })
                .PrimaryKey(t => t.RID);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        MobileNo = c.String(),
                        PostCode = c.String(),
                        PresentAddress = c.String(),
                        Education = c.String(),
                        DoB = c.DateTime(),
                        NID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zones",
                c => new
                    {
                        ZonID = c.Int(nullable: false, identity: true),
                        ZoneCode = c.String(),
                        ZoneName = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.ZonID);
            
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BranchCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "ZoneID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ZoneID");
            DropColumn("dbo.AspNetUsers", "BranchCode");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Description");
            DropTable("dbo.Zones");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Religions");
            DropTable("dbo.Occupations");
            DropTable("dbo.Branches");
        }
    }
}
