namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        appointdate = c.DateTime(nullable: false),
                        ptId = c.Int(nullable: false),
                        docId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Doctors", t => t.docId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.ptId, cascadeDelete: true)
                .Index(t => t.ptId)
                .Index(t => t.docId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        speciality = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "ptId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "docId", "dbo.Doctors");
            DropIndex("dbo.Appointments", new[] { "docId" });
            DropIndex("dbo.Appointments", new[] { "ptId" });
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
