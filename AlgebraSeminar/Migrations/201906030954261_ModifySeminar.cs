namespace AlgebraSeminar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySeminar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seminar", "Predavac", c => c.String());
            AlterColumn("dbo.Seminar", "Naziv", c => c.String(nullable: false));
            AlterColumn("dbo.Seminar", "Opis", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seminar", "Opis", c => c.String());
            AlterColumn("dbo.Seminar", "Naziv", c => c.String());
            DropColumn("dbo.Seminar", "Predavac");
        }
    }
}
