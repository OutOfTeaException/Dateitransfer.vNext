namespace Dateitransfer.vNext.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Directory = c.String(),
                        FileMask = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Outputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Directory = c.String(),
                        Input_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inputs", t => t.Input_Id)
                .Index(t => t.Input_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cron = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        LastRun = c.DateTime(nullable: false),
                        Input_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inputs", t => t.Input_Id)
                .Index(t => t.Input_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Input_Id", "dbo.Inputs");
            DropForeignKey("dbo.Outputs", "Input_Id", "dbo.Inputs");
            DropIndex("dbo.Jobs", new[] { "Input_Id" });
            DropIndex("dbo.Outputs", new[] { "Input_Id" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Outputs");
            DropTable("dbo.Inputs");
        }
    }
}
