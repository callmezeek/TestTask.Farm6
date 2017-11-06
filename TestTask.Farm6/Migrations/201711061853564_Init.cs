namespace TestTask.Farm6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Farmer = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Kultur = c.String(nullable: false),
                        LastYearHarvest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GisX = c.Double(),
                        GisY = c.Double(),
                        Region = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Farms");
        }
    }
}
