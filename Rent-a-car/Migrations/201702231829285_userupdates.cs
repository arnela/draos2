namespace Rent_a_car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userupdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "FirstName", c => c.String());
            AddColumn("dbo.ApplicationUsers", "LastName", c => c.String());
            AddColumn("dbo.ApplicationUsers", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Location");
            DropColumn("dbo.ApplicationUsers", "LastName");
            DropColumn("dbo.ApplicationUsers", "FirstName");
        }
    }
}
