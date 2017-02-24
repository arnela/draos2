namespace Rent_a_car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentacar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Reservations", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "IsActive");
            DropColumn("dbo.Reservations", "IsApproved");
        }
    }
}
