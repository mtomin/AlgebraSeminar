namespace AlgebraSeminar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedClasses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Predbiljezba", "Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Predbiljezba", "Email", c => c.String(nullable: false));
        }
    }
}
