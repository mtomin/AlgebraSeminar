namespace AlgebraSeminar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Zaposlenik", "Ime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Zaposlenik", "Prezime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Zaposlenik", "KorisnickoIme", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Zaposlenik", "Lozinka", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Zaposlenik", "LozinkaSalt", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zaposlenik", "LozinkaSalt", c => c.String(nullable: false));
            AlterColumn("dbo.Zaposlenik", "Lozinka", c => c.String(nullable: false));
            AlterColumn("dbo.Zaposlenik", "KorisnickoIme", c => c.String(nullable: false));
            AlterColumn("dbo.Zaposlenik", "Prezime", c => c.String(nullable: false));
            AlterColumn("dbo.Zaposlenik", "Ime", c => c.String(nullable: false));
        }
    }
}
