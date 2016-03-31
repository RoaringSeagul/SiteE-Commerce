namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDImageINArticles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ImageNom", c => c.String());
            AddColumn("dbo.Articles", "ImageType", c => c.String());
            AddColumn("dbo.Articles", "ImageTaille", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ImageData");
            DropColumn("dbo.Articles", "ImageTaille");
            DropColumn("dbo.Articles", "ImageType");
            DropColumn("dbo.Articles", "ImageNom");
        }
    }
}
