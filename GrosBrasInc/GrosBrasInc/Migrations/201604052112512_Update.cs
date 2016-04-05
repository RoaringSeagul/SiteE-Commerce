namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        MessageBody = c.String(),
                        SujetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Sujets", t => t.SujetID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.SujetID);
            
            CreateTable(
                "dbo.Sujets",
                c => new
                    {
                        SujetID = c.Int(nullable: false, identity: true),
                        SubjectTitle = c.String(),
                        SubjectBody = c.String(),
                    })
                .PrimaryKey(t => t.SujetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SujetID", "dbo.Sujets");
            DropForeignKey("dbo.Messages", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SujetID" });
            DropIndex("dbo.Messages", new[] { "ApplicationUserID" });
            DropTable("dbo.Sujets");
            DropTable("dbo.Messages");
        }
    }
}
