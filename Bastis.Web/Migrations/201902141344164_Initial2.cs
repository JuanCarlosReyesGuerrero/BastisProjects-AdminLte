namespace Bastis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Guid(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Agent_AgentID = c.Guid(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentID)
                .Index(t => t.Agent_AgentID);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        LeadID = c.Guid(nullable: false),
                        UserRegisters = c.Guid(),
                        DateRegister = c.DateTime(),
                        UserModifies = c.Guid(),
                        DateModified = c.DateTime(),
                        Agent_AgentID = c.Guid(),
                        Property_PropertyID = c.Int(),
                    })
                .PrimaryKey(t => t.LeadID)
                .ForeignKey("dbo.Agents", t => t.Agent_AgentID)
                .ForeignKey("dbo.Properties", t => t.Property_PropertyID)
                .Index(t => t.Agent_AgentID)
                .Index(t => t.Property_PropertyID);
            
            AddColumn("dbo.Properties", "Client_ClientID", c => c.Guid());
            CreateIndex("dbo.Properties", "Client_ClientID");
            AddForeignKey("dbo.Properties", "Client_ClientID", "dbo.Clients", "ClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leads", "Property_PropertyID", "dbo.Properties");
            DropForeignKey("dbo.Leads", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Properties", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Agent_AgentID", "dbo.Agents");
            DropIndex("dbo.Leads", new[] { "Property_PropertyID" });
            DropIndex("dbo.Leads", new[] { "Agent_AgentID" });
            DropIndex("dbo.Clients", new[] { "Agent_AgentID" });
            DropIndex("dbo.Properties", new[] { "Client_ClientID" });
            DropColumn("dbo.Properties", "Client_ClientID");
            DropTable("dbo.Leads");
            DropTable("dbo.Clients");
        }
    }
}
