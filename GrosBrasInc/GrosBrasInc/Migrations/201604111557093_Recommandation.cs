namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Recommandation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Recommandation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Recommandation");
        }
    }
}
