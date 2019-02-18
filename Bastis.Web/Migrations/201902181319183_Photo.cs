namespace Bastis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Photo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoID = c.Guid(nullable: false),
                        URLPhoto = c.String(),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Property_PropertyID = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoID)
                .ForeignKey("dbo.Properties", t => t.Property_PropertyID)
                .Index(t => t.Property_PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Property_PropertyID", "dbo.Properties");
            DropIndex("dbo.Photos", new[] { "Property_PropertyID" });
            DropTable("dbo.Photos");
        }
    }
}
