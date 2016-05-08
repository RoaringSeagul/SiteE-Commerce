namespace GrosBrasInc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Poid", c => c.Double(nullable: false));
            AddColumn("dbo.Articles", "Hauteur", c => c.Double(nullable: false));
            AddColumn("dbo.Articles", "Largeur", c => c.Double(nullable: false));
            AddColumn("dbo.Articles", "Grandeur", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Company", c => c.String());
            AddColumn("dbo.Orders", "Departement", c => c.String());
            AddColumn("dbo.Orders", "StreetNumber", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.Orders", "StreetName", c => c.String());
            AddColumn("dbo.Orders", "StreetType", c => c.String());
            AddColumn("dbo.Orders", "Suite", c => c.String());
            AddColumn("dbo.Orders", "Floor", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "StreetAddress2", c => c.String());
            AddColumn("dbo.Orders", "StreetAddress3", c => c.String());
            AddColumn("dbo.Orders", "Province", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "PhoneNumber", c => c.String(nullable: false, maxLength: 24));
            AlterColumn("dbo.Articles", "Prix", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Total", c => c.Single(nullable: false));
            AlterColumn("dbo.Articles", "Prix", c => c.Single(nullable: false));
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "Province");
            DropColumn("dbo.Orders", "StreetAddress3");
            DropColumn("dbo.Orders", "StreetAddress2");
            DropColumn("dbo.Orders", "Floor");
            DropColumn("dbo.Orders", "Suite");
            DropColumn("dbo.Orders", "StreetType");
            DropColumn("dbo.Orders", "StreetName");
            DropColumn("dbo.Orders", "StreetNumber");
            DropColumn("dbo.Orders", "Departement");
            DropColumn("dbo.Orders", "Company");
            DropColumn("dbo.Articles", "Grandeur");
            DropColumn("dbo.Articles", "Largeur");
            DropColumn("dbo.Articles", "Hauteur");
            DropColumn("dbo.Articles", "Poid");
        }
    }
}
