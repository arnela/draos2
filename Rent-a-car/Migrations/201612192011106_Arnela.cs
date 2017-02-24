using System.Data.Entity.Migrations;

namespace Rent_a_car.Migrations
{

    
    public partial class Arnela : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Title = c.String(nullable: false),
                        AirCondition = c.Boolean(nullable: false),
                        MaxNumberOfPerson = c.Int(nullable: false),
                        TypeOfFuel = c.Int(nullable: false),
                        Consumption = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Car");
        }
    }
}
