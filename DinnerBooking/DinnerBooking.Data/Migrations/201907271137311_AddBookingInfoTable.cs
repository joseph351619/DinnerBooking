namespace DinnerBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookingInfoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        MailSent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookings");
        }
    }
}
