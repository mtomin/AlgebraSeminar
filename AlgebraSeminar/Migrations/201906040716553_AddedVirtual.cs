namespace AlgebraSeminar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVirtual : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezba", "Ime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Predbiljezba", "Prezime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Predbiljezba", "Adresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Predbiljezba", "Telefon", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Seminar", "Naziv", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Seminar", "Opis", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Seminar", "Predavac", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seminar", "Predavac", c => c.String(nullable: false));
            AlterColumn("dbo.Seminar", "Opis", c => c.String(nullable: false));
            AlterColumn("dbo.Seminar", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezba", "Telefon", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezba", "Adresa", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezba", "Prezime", c => c.String(nullable: false));
            AlterColumn("dbo.Predbiljezba", "Ime", c => c.String(nullable: false));
        }
    }
}
