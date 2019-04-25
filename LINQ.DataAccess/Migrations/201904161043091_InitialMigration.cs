namespace LINQ.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Duration = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Performer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.Performer_Id)
                .Index(t => t.Performer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Performer_Id", "dbo.Performers");
            DropIndex("dbo.Songs", new[] { "Performer_Id" });
            DropTable("dbo.Songs");
            DropTable("dbo.Performers");
        }
    }
}
