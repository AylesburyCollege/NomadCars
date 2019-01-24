namespace NomadCars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetrolTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarSpecs", "FuelType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarSpecs", "FuelType");
        }
    }
}
