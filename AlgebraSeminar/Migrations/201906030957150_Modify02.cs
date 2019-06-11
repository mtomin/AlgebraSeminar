namespace AlgebraSeminar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modify02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Seminar", "Predavac", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Seminar", "Predavac", c => c.String());
        }
    }
}
