namespace SoftDesign.Library.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        Author = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Isbn = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BookId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                        RentalDate = c.DateTime(nullable: false, precision: 0),
                        ExpectedReturnDate = c.DateTime(nullable: false, precision: 0),
                        ActualReturnDate = c.DateTime(precision: 0),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        PasswordHash = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        PasswordSalt = c.String(unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        FirstName = c.String(maxLength: 100, storeType: "nvarchar"),
                        LastName = c.String(maxLength: 100, storeType: "nvarchar"),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                        DeletedDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rentals", "BookId", "dbo.Books");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Rentals", new[] { "UserId" });
            DropIndex("dbo.Rentals", new[] { "BookId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rentals");
            DropTable("dbo.Books");
        }
    }
}
