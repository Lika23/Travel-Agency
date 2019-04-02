namespace TravelAgency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookedTours",
                c => new
                    {
                        BookedTourId = c.Int(nullable: false, identity: true),
                        Tour_TourId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BookedTourId)
                .ForeignKey("dbo.Tours", t => t.Tour_TourId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Tour_TourId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        TourId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TourId)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.FavoriteTours",
                c => new
                    {
                        FavoriteTourId = c.Int(nullable: false, identity: true),
                        Tour_TourId = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FavoriteTourId)
                .ForeignKey("dbo.Tours", t => t.Tour_TourId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Tour_TourId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Class = c.Int(nullable: false),
                        Address = c.String(),
                        Nutrition = c.String(),
                        ResortId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Country_Id = c.Int(),
                        Hotel_HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .Index(t => t.Country_Id)
                .Index(t => t.Hotel_HotelId);
            
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        ResortId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Infrastructure = c.String(),
                        Description = c.String(),
                        History = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResortId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Pictures", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "ResortId", "dbo.Resorts");
            DropForeignKey("dbo.Resorts", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Pictures", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.FavoriteTours", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookedTours", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavoriteTours", "Tour_TourId", "dbo.Tours");
            DropForeignKey("dbo.BookedTours", "Tour_TourId", "dbo.Tours");
            DropIndex("dbo.Resorts", new[] { "CountryId" });
            DropIndex("dbo.Pictures", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Pictures", new[] { "Country_Id" });
            DropIndex("dbo.Hotels", new[] { "ResortId" });
            DropIndex("dbo.FavoriteTours", new[] { "User_Id" });
            DropIndex("dbo.FavoriteTours", new[] { "Tour_TourId" });
            DropIndex("dbo.Tours", new[] { "HotelId" });
            DropIndex("dbo.BookedTours", new[] { "User_Id" });
            DropIndex("dbo.BookedTours", new[] { "Tour_TourId" });
            DropTable("dbo.Resorts");
            DropTable("dbo.Pictures");
            DropTable("dbo.Hotels");
            DropTable("dbo.FavoriteTours");
            DropTable("dbo.Tours");
            DropTable("dbo.BookedTours");
        }
    }
}
