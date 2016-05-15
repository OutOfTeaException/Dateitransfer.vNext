namespace Dateitransfer.vNext.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterJobSetLastRunToNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Outputs", "Input_Id", "dbo.Inputs");
            DropIndex("dbo.Outputs", new[] { "Input_Id" });
            DropIndex("dbo.Jobs", new[] { "Input_Id" });
            DropPrimaryKey("dbo.Jobs");
            DropColumn("dbo.Jobs", "Id");
            RenameColumn(table: "dbo.Outputs", name: "Input_Id", newName: "InputId");
            RenameColumn(table: "dbo.Jobs", name: "Input_Id", newName: "Id");
            AddColumn("dbo.Inputs", "JobId", c => c.Int(nullable: false)); //?
            AddColumn("dbo.Jobs", "InputId", c => c.Int(nullable: false));
            AlterColumn("dbo.Outputs", "InputId", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "LastRun", c => c.DateTime());
            AlterColumn("dbo.Jobs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Jobs", "Id");
            CreateIndex("dbo.Jobs", "Id");
            CreateIndex("dbo.Outputs", "InputId");
            AddForeignKey("dbo.Outputs", "InputId", "dbo.Inputs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outputs", "InputId", "dbo.Inputs");
            DropIndex("dbo.Outputs", new[] { "InputId" });
            DropIndex("dbo.Jobs", new[] { "Id" });
            DropPrimaryKey("dbo.Jobs");
            AlterColumn("dbo.Jobs", "Id", c => c.Int());
            AlterColumn("dbo.Jobs", "LastRun", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Outputs", "InputId", c => c.Int());
            DropColumn("dbo.Jobs", "InputId");
            DropColumn("dbo.Inputs", "JobId");
            AddPrimaryKey("dbo.Jobs", "Id");
            RenameColumn(table: "dbo.Jobs", name: "Id", newName: "Input_Id");
            RenameColumn(table: "dbo.Outputs", name: "InputId", newName: "Input_Id");
            AddColumn("dbo.Jobs", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Jobs", "Input_Id");
            CreateIndex("dbo.Outputs", "Input_Id");
            AddForeignKey("dbo.Outputs", "Input_Id", "dbo.Inputs", "Id");
        }
    }
}
